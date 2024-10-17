# Rox.OmniChannel API

## Descrição
Este projeto é uma API ASP.NET Core que utiliza autenticação baseada em **JWT (JSON Web Token)**, com suporte a **multi-tenant** e diferentes roles de usuário, como **Customer**, **TenantManager**, e **Administrador**. A API serve tanto para um sistema web de gerenciamento quanto para um sistema mobile. A estrutura do projeto é organizada em quatro camadas:

- **Rox.OmniChannel.Api**: Camada de apresentação (API), onde as requisições HTTP são recebidas.
- **Rox.OmniChannel.CrossCutting**: Contém utilitários e serviços compartilhados entre as outras camadas.
- **Rox.OmniChannel.Domain**: Lógica de negócios e modelos de domínio.
- **Rox.OmniChannel.Infrastructure**: Acesso a dados e configurações de infraestrutura.

## Estrutura de Roles

- **Customer**: Usuário do sistema mobile.
- **TenantManager**: Usuário do sistema web de gerenciamento.
- **Administrador**: Usuário administrador do sistema com permissões totais.

## Funcionalidades

- Autenticação com JWT, incluindo a emissão de tokens que contêm informações sobre o usuário, seus tenants e sua role.
- Suporte a múltiplos tenants, permitindo que um usuário esteja associado a vários tenants simultaneamente.
- Autorização baseada em roles e tenants, controlando o acesso a diferentes endpoints de acordo com as permissões do usuário.
- Estrutura modular em camadas, facilitando a separação de responsabilidades e manutenção.

## Tecnologias Utilizadas

- **ASP.NET Core**
- **Entity Framework Core**
- **JWT (JSON Web Tokens)**
- **Microsoft Identity** para gerenciamento de usuários e autenticação
- **SQL Server** (ou qualquer banco de dados suportado pelo Entity Framework)
- **Azure Cloud Services** (se aplicável)

## Contribuindo

Se você deseja contribuir com este projeto, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma branch para sua feature ou correção de bug:
   ```bash
   git checkout -b minha-feature
   
3. Faça commit das suas mudanças:
  ```bash
  git commit -m 'Adiciona nova feature'
  git push origin minha-feature
