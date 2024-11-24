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
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Alterar(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            var productAlterado = await _repository.Alterar(product);
            return _mapper.Map<ProductDTO>(productAlterado);
        }

        public async Task<ProductDTO> Excluir(int id)
        {
            var productExcluido = await _repository.Excluir(id);
            return _mapper.Map<ProductDTO>(productExcluido);
        }

        public async Task<ProductDTO> Incluir(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            /*
            product.CycleTime = 1.23M;
            if (product.CycleTime <= 0)
            {
                product.CycleTime = 0.01M; // Valor mínimo válido */
            
            var productIncluido = await _repository.Incluir(product);
            return _mapper.Map<ProductDTO>(productIncluido);
        }

        public async Task<ProductDTO> SelecionarAsync(int id)
        {
            var product = await _repository.SelecionarAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<IEnumerable<ProductDTO>> SelecionarTodosAsync()
        {
            var products = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
