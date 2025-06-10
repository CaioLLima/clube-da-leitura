# ClubeDaLeitura

## 🧪 Exemplos de Execução
![Gif Projeto](https://i.imgur.com/SYG6Fmh.gif)

## 🧾 Sobre o Projeto

Este sistema simula um clube de leitura onde amigos podem emprestar revistas organizadas em caixas. Cada caixa define um prazo de devolução, e o sistema controla os empréstimos, status das revistas e histórico dos usuários.

---

## 🚀 Funcionalidades

### ✅ Módulo de Amigos
- Cadastrar, editar, excluir e visualizar amigos.
- Visualizar os empréstimos de um amigo.
- Regras:
  - Nome e telefone obrigatórios.
  - Não permitir duplicidade de nome + telefone.
  - Não permitir excluir amigo com empréstimos ativos.

### ✅ Módulo de Caixas
- Cadastrar, editar, excluir e visualizar caixas.
- Regras:
  - Etiqueta única.
  - Define cor e prazo de empréstimo (dias).
  - Não excluir se houver revistas associadas.

### ✅ Módulo de Revistas
- Cadastrar, editar, excluir e visualizar revistas.
- Associar revista a uma caixa.
- Mostrar status: Disponível, Emprestada ou Reservada.
- Regras:
  - Título e edição obrigatórios.
  - Revistas com mesmo título + edição não podem se repetir.

### ✅ Módulo de Empréstimos
- Registrar novos empréstimos.
- Calcular devolução com base na caixa.
- Registrar devoluções.
- Destacar empréstimos atrasados.
- Regras:
  - Um amigo só pode ter um empréstimo ativo.
  - Apenas revistas disponíveis podem ser emprestadas.

---

## 🏗️ Arquitetura do Projeto

- Programação orientada a objetos
- Separação em 3 camadas:
  - Apresentação (`Tela*`)
  - Domínio (`Entidade*`)
  - Dados (`Repositorio*`)
- Uso de herança e polimorfismo com `TelaBase`, `TelaPrincipal`,  `RepositorioBase` e `EntidadeBase`.


[![My Skills](https://skillicons.dev/icons?i=cs,dotnet,visualstudio,git,github)](https://skillicons.dev)
