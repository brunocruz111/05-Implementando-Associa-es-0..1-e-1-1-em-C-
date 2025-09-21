
Implementação de Vínculos em C#: Usuário (1:1) e Cliente (0..1)
Este projeto demonstra a correta implementação de associações 1:1 (obrigatória) e 0..1 (opcional) em C#, seguindo os princípios de design por contrato, validação na fronteira e navegabilidade mínima, conforme as diretrizes da atividade.

Cenário Escolhido
O cenário modelado abrange duas associações distintas:

Usuário e Dados Biométricos (1:1): Um Usuário é uma entidade que sempre deve ter DadosBiometricos para fins de autenticação. A associação é obrigatória na criação do Usuário e imutável. Um conjunto de dados biométricos pertence a um único usuário.

Cliente e Endereço de Entrega Preferencial (0..1): Um Cliente pode ter um EnderecoPreferencial. Este vínculo é opcional, podendo o endereço ser adicionado ou removido após a criação do cliente. Um endereço preferencial, se existir, pertence a um único cliente.

Invariantes de Domínio e Justificativas
Vínculo 1:1: Usuário e DadosBiometricos
Invariante: Um Usuário deve sempre ter um DadosBiometricos associado.

Garantia por Design:

O DadosBiometricos é exigido como parâmetro no construtor da classe Usuario.

A propriedade BiometricData é get-only, garantindo que não possa ser alterada após a criação do objeto.

Uma validação na fronteira (ArgumentNullException) impede a criação de um Usuário com dados biométricos nulos.

Vínculo 0..1: Cliente e EnderecoPreferencial
Invariante: Um Cliente pode ter no máximo um EnderecoPreferencial e a ausência é válida.

Garantia por Design:

A propriedade PreferredAddress é anulável (Endereco?) e tem private set, impedindo atribuições diretas de fora da classe.

Um método de domínio (AtribuirEnderecoPreferencial) controla a atribuição, verificando se um endereço já está atribuído e se o novo endereço não é nulo.

Um método RemoverEnderecoPreferencial permite que o vínculo seja desfeito, restaurando o estado nulo.

Decisões de Navegabilidade
Ambas as associações são unidirecionais. A navegabilidade foi definida do objeto "mestre" para o objeto "dependente" (Usuario -> DadosBiometricos e Cliente -> Endereco).

Não há necessidade de navegabilidade inversa (DadosBiometricos -> Usuário), pois o caso de uso não exige que os dados biométricos saibam a que usuário pertencem.

Similarmente, não é necessário que o EnderecoPreferencial saiba a que Cliente pertence.

Essa abordagem de direção mínima reduz o acoplamento, simplifica a lógica de sincronização de estado e torna o modelo mais robusto e fácil de manter.
