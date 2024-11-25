using AutoMapper;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Application.Interfaces;
using ProductionOrderSEQUOR.Domain.Entities;
using ProductionOrderSEQUOR.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IProductionRepository _repository;
        private readonly IMapper _mapper;

        public ProductionService(IProductionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ProductionDTO> Incluir(ProductionPostDTO productionPostDTO)
        {
            var production = _mapper.Map<Production>(productionPostDTO);
            var productionIncluido = await _repository.Incluir(production);
            return _mapper.Map<ProductionDTO>(productionIncluido);
        }

        public async Task<ProductionDTO> Alterar(ProductionDTO productionDTO)
        {
            // Carrega a entidade existente com o mesmo ID
            var existingProduction = await _repository.SelecionarAsync(productionDTO.Id);
            if (existingProduction == null)
            {
                throw new Exception("Produção não encontrada");
            }

            // Atualiza os campos da entidade existente com os dados do DTO
            _mapper.Map(productionDTO, existingProduction);

            // Chama o repositório para atualizar a entidade no banco de dados
            var productionAlterado = await _repository.Alterar(existingProduction);
            return _mapper.Map<ProductionDTO>(productionAlterado);
        }


        public async Task<ProductionDTO> Excluir(int id)
        {
            var productionExcluido = await _repository.Excluir(id);
            return _mapper.Map<ProductionDTO>(productionExcluido);
        }


        public async Task<ProductionDTO> SelecionarAsync(int id)
        {
            var production = await _repository.SelecionarAsync(id);
            return _mapper.Map<ProductionDTO>(production);
        }
        public async Task<IEnumerable<ProductionDTO>> SelecionarTodosAsync()
        {
            var productions = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<ProductionDTO>>(productions);

        }
    }
}
