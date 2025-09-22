# Roteiro de Testes — Trabalho 5 (Associações 1:1 e 0..1)

Este roteiro descreve os passos para validar as associações **1:1** (obrigatória) e **0..1** (opcional) no projeto em C#.  
As evidências devem ser coletadas por meio de **prints de tela** da saída do console após cada passo.

---

## Passo 1 — Criar `Usuario` com `DadosBiometricos`
**Ação:**  
- Instanciar `Usuario` com um objeto `DadosBiometricos` válido.  
- Executar o programa (`dotnet run`).  

**Resultado esperado:**  
[1] Criar Usuario com DadosBiometricos (esperado: sucesso)
-> Criado: Usuario[Nome=Alice Silva] -> DadosBiometricos[Tipo=Digital, CapturadoEm=2025-09-21T...Z]

**Evidência:**  
- Capturar print da saída acima no console.

---

## Passo 2 — Criar `Usuario` sem `DadosBiometricos`
**Ação:**  
- Instanciar `Usuario` com `null` no construtor de `DadosBiometricos`.  

**Resultado esperado:**  
[2] Tentar criar Usuario sem DadosBiometricos (esperado: falha)
-> Exceção esperada: ArgumentNullException - DadosBiometricos obrigatório. (Parameter 'biometria')

**Evidência:**  
- Capturar print da saída no console mostrando a exceção.

---

## Passo 3 — Criar `Cliente` sem `EnderecoPreferencial`
**Ação:**  
- Criar `Cliente` sem fornecer endereço.  

**Resultado esperado:**  
[3] Criar Cliente sem EnderecoPreferencial (esperado: sem endereco)
-> Cliente[Nome=Empresa Exemplo] EnderecoPref=(nenhum)

**Evidência:**  
- Capturar print do console.

---

## Passo 4 — Definir `EnderecoPreferencial` para `Cliente`
**Ação:**  
- Chamar `DefinirEnderecoPreferencial()` com endereço válido.  

**Resultado esperado:**  
[4] Definir EnderecoPreferencial (esperado: atribuição bem sucedida)
-> DefinirEnderecoPreferencial returned True; Cliente = Cliente[Nome=Empresa Exemplo] EnderecoPref=Rua Alfa, 100, Medianeira

**Evidência:**  
- Capturar print da saída.

---

## Passo 5 — Tentar sobrescrever endereço sem remover
**Ação:**  
- Chamar `DefinirEnderecoPreferencial()` novamente com outro endereço, sem remover o primeiro.  

**Resultado esperado:**  
[5] Tentar sobrescrever endereco sem remover (esperado: falha)
-> Tentativa sobrescrever returned False; Cliente = Cliente[Nome=Empresa Exemplo] EnderecoPref=Rua Alfa, 100, Medianeira

**Evidência:**  
- Capturar print da saída.

---

## Passo 6 (Opcional) — Remover e atribuir novo endereço
**Ação:**  
- Remover endereço com `RemoverEnderecoPreferencial()` e depois atribuir um novo endereço.  

**Resultado esperado:**  
[6] Remover endereco e atribuir novo (esperado: remover=true, atribuir=true)
-> Remover returned True; Definir returned True; Cliente = Cliente[Nome=Empresa Exemplo] EnderecoPref=Avenida Beta, 200, Toledo

**Evidência:**  
- Capturar print da saída.

---

## Conclusão
Seguindo os passos acima, é possível validar:
- A obrigatoriedade da associação **1:1** (`Usuario` → `DadosBiometricos`)
- A opcionalidade e unicidade da associação **0..1** (`Cliente` → `EnderecoPreferencial`)
- O comportamento correto para criação, atribuição, falha de sobrescrita e remoção.
