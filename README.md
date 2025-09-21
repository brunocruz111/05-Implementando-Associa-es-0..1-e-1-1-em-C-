Este repositório contém o Trabalho 5 desenvolvido na disciplina de Programação Orientada a Objetos da Universidade Tecnológica Federal do Paraná (UTFPR) - Câmpus Medianeira.
📘 Informações da Disciplina

Curso: Ciência da Computação
Disciplina: Programação Orientada a Objetos
Professor: Everton Coimbra

👥 Integrantes do Grupo

Alan Lino dos Reis
Bruno Luis da Cruz
Hilário Canci Neto
Pedro Gabriel Sepulveda Borgheti
Pedro Lucas Reis

1. Cenário e Invariantes de Domínio
O cenário proposto modela duas relações fundamentais entre classes:

Vínculo 1:1 (Obrigatório): Uma Pessoa (Pessoa) deve ter exatamente um Cpf (Cadastro de Pessoa Física). O Cpf é um dado de identificação que não faz sentido existir sem estar vinculado a uma Pessoa.

Vínculo 0..1 (Opcional): Um Autor (Autor) pode ter ou não um Blog. A existência do Blog é opcional, mas se ele existir, estará associado a um Autor.

Invariantes de Domínio:

Para o Cpf: Um Cpf não pode ser nulo ou vazio e deve ser composto por 11 caracteres numéricos.

Para a Pessoa: Uma Pessoa deve ser criada com um Cpf válido.

Para o Autor: Um Autor deve ter um nome válido. Se um Blog for associado a um Autor, seu título não pode ser nulo ou vazio.

Vínculos:

A relação Pessoa-Cpf é de composição obrigatória (1:1).

A relação Autor-Blog é de associação opcional (0..1).

2. Navegabilidade Mínima
A navegabilidade foi projetada para ser mínima, evitando acoplamento desnecessário entre as classes:

Pessoa -> Cpf: A classe Pessoa sabe qual é o seu Cpf. A classe Cpf não precisa saber a qual Pessoa pertence, pois seu papel é apenas encapsular e validar o valor do CPF.

Autor -> Blog: A classe Autor sabe qual é o seu Blog, se houver. A classe Blog não precisa saber qual Autor o escreve.

3. Validação na Fronteira
Toda a validação dos dados de entrada é realizada nos construtores das classes, garantindo que nenhum objeto inválido possa ser instanciado. Exceções (ArgumentException) são lançadas caso os dados não atendam aos requisitos. Isso é conhecido como "fail-fast" e ajuda a manter a integridade do domínio desde a criação dos objetos.
