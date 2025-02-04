# ProductOrdersAPI

## 📌 Visão Geral
ProductOrdersAPI é uma API desenvolvida em **C#** utilizando **.NET Core** e **SQL Server** para gerenciamento de ordens de produção.
A API fornece endpoints para criação, consulta, atualização e exclusão de ordens de produção, garantindo a integridade dos dados por meio de validações específicas.

## 🚀 Tecnologias Utilizadas
- **C#**
- **.NET Core 3.0**
- **SQL Server**
- **Entity Framework Core**
- **Swagger (OpenAPI)**
- **Windows Forms (.NET Framework)** para interface de gerenciamento

## ⚙️ Funcionalidades
✅ Gerenciamento de ordens de produção
✅ Validações específicas para email, ordem, data de apontamento, quantidade, material e tempo de ciclo
✅ Integração com banco de dados SQL Server
✅ API RESTful com documentação via Swagger
✅ Interface desktop para gestão das ordens

## 🛠️ Como Executar o Projeto
### 🔧 Requisitos
- **.NET Core SDK 3.0**
- **SQL Server** (instalado e configurado)
- **Visual Studio** (recomendado para desenvolvimento e depuração)

### 🔽 Configuração do Banco de Dados

Importe o **Banco de de dados** no SQL Server, o arquivo encontra-se neste projeto com o nome: ProductionOrders.BAK. 

Ou --->\/ 

1. Criar o banco de dados no SQL Server:
   ```sql
   CREATE DATABASE ProductionOrdersDB;
   ```
2. Configurar a string de conexão no **appsettings.json**:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=ProductionOrdersDB;User Id=sa;Password=S&QU0Rtec2024;"
     }
   }
   ```
3. Executar as migrações:
   ```sh
   dotnet ef database update
   ```

### 🚀 Executando a API
1. No terminal, dentro do diretório do projeto, execute:
   ```sh
   dotnet run
   ```
2. A API estará disponível em:
   ```
   http://localhost:5000
   ```
3. Acesse a documentação no Swagger:
   ```
   http://localhost:5000/swagger
   ```

## 📂 Estrutura do Projeto
```
ProductOrdersAPI/
├── Controllers/
│   ├── OrdersController.cs
├── Models/
│   ├── Order.cs
├── Data/
│   ├── ApplicationDbContext.cs
├── Services/
│   ├── OrderService.cs
├── appsettings.json
├── Program.cs
├── Startup.cs
└── README.md
```

## 📌 Endpoints Principais
### 🔹 Criar uma ordem de produção
```http
POST /api/orders
```
#### **Exemplo de JSON:**
```json
{
  "orderNumber": "12345",
  "material": "Aço Inox",
  "quantity": 100,
  "productionDate": "2024-02-04T08:00:00",
  "cycleTime": 5.5,
  "email": "operador@fabrica.com"
}
```

### 🔹 Listar todas as ordens
```http
GET /api/orders
```

### 🔹 Buscar uma ordem por ID
```http
GET /api/orders/{id}
```

### 🔹 Atualizar uma ordem
```http
PUT /api/orders/{id}
```

### 🔹 Deletar uma ordem
```http
DELETE /api/orders/{id}
```
### 🔹 Acesso administrador login: admin@admin.com.br - senha: password 


## 📝 Autor
Projeto desenvolvido por **Marcelo Magalhães**. 🚀

