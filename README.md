# conta-corrente

O seguinte prejeto utilizou as seguintes tecnologias:
- Front: Angula web
- Back: .Net 7
- Base de dados SQL Server
- ORM Entity Framework
- Identity

Foi utilizado e ideia de microserviços para dividir as responsábilidades entre Autenticação e Registro (API de autenticação) e Movimentações, saques e depósitos (API de Transações).
Ambos contam com a documentação Rest padrão fornecida pelo template, o Swagger.

A tarefa de se utilizar microserviços foi simulado, valendo a ressalva de que o padrão microsserviços apresenta ideias mais robustas e que a título de teste talvez fosse pouco necessário explorar, como por exemplo a separação de bases para cada um dos contextos.
Nesse caso, utilizei apenas uma base para os dois. Outro ponto é a comunicação entre esses dois serviços. Como a Api "central" ou de autenticação nesse caso também foi responsável por criar uma conta corrente, faria sentido que esta também atualizasse o saldo.
Uma tarefa que ficou pendente e que traria uma ótima melhoria de design seria o envio de uma mensagem para atualização de saldo via serviço de menssageria. Por estarem no mesmo contexto de dados acabei fazendo manualmente mas na sobra de tempo esse seria um próximo passo.

O front-end foi criado em Angular JS e formulários reativos. A parte de login e cadastro estão funcionando perfeitamente e com boas validações. Não foi possível terminar o restante das atividades de front dado curto período e compromissos pessoais.

Ainda sobre o contexto de microsserviços, criei projetos estáticos para gerenciar o contexto de dados entre as duas APIs e também um projeto de infra que disponibilizasse para ambos o core acerca dos dados de autenticação, fazendo com que ambos compartilhassem esse conhecimento e assim não tivessem que cada um registrar dados repetidos.

No mais para qualquer dúvida estarei à disposição para ajudá-los.
Entre as funcionalidades criadas estão:
- Registro de usuário
- Autenticação de usuário
- Criação de contas correntes para usuário
- Buscar contas correntes e suas movimentações
- Criar movimentações (saque e depósito)
- Validação de saldo para saque
- Validação de usuário para saque

Acerca dos testes
Não foi possível completar os testes pois dado o período de tempo não consegui terminar as tarefas para finalizá-los.
Mas minha estratégia seria criar testes de integrações completos e que validassem a aplicação de maneira confiável. Para uma aplicação tão simples e que não possui serviços de grande manuseio uma cobertura de integração para o BackEnd me parece confiável o suficiente para validar grande parte da aplicação.
Os testes unitários fariam bastante sentido no módulo mais crítico do sistema que seria as movimentações. A união de testes unitários e de integração nesse módulo validaria consideravelmente nosso projeto.
Os testes de Front-Back com selenium elevariam a confiabilidade dos nossos projetos a um nível acima. Infelizmente este foi o que mais me distanciei por não ter finalizado o front por completo, mas traria confiabilidade completa acerca dos módulos.
