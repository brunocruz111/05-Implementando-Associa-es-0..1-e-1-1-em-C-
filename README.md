# Trabalho 5 — Associações 1:1 e 0..1 em C#

Este repositório contém o **Trabalho 5** desenvolvido na disciplina de **Programação Orientada a Objetos** da **Universidade Tecnológica Federal do Paraná (UTFPR)** - Câmpus Medianeira. 📘

**Informações da Disciplina**  
Curso: Ciência da Computação  
Disciplina: Programação Orientada a Objetos  
Professor: Everton Coimbra

**Integrantes do Grupo**  
- Alan Lino dos Reis  
- Bruno Luis da Cruz  
- Hilário Canci Neto  
- Pedro Gabriel Sepulveda Borgheti  
- Pedro Lucas Reis

---

## Objetivo
Implementar, em C#, duas associações entre classes que cubram as multiplicidades:
- **1:1 (obrigatório)** — `Usuario` ↔ `DadosBiometricos` (each `Usuario` must have one `DadosBiometricos`)
- **0..1 (opcional)** — `Cliente` ↔ `EnderecoPreferencial` (a `Cliente` may have zero or one preferred address)

Garantir invariantes de domínio por design, validação na fronteira e navegabilidade mínima.

---

## Cenário e decisões principais
- **Cenário:**  
  - `Usuario` representa um usuário do sistema. Cada `Usuario` **obrigatoriamente** possui um `DadosBiometricos` (1:1).
  - `Cliente` representa um cliente/empresa que pode ter um `EnderecoPreferencial` opcional (0..1).

- **Invariantes garantidas por design:**
  1. `Usuario` **não pode** ser instanciado sem um `DadosBiometricos` válido (construtor exige o dependente).
  2. `Cliente` pode ter **no máximo um** `EnderecoPreferencial`. Atribuições só via método `DefinirEnderecoPreferencial` e só ocorrerá se não houver um endereço já definido.

- **Validações de fronteira:**
  - Campos obrigatórios (nome, tipo de biometria, rua, cidade) não podem ser nulos/vazios.
  - Data de captura da biometria não pode estar no futuro.
  - Tentativa de criar `Usuario` sem `DadosBiometricos` lança `ArgumentNullException`.
  - Tentativa de sobrescrever `EnderecoPreferencial` falha (retorna `false`) sem remoção prévia.

- **Navegabilidade mínima:**
  - Direção única: `Usuario` → `DadosBiometricos` e `Cliente` → `EnderecoPreferencial`.
  - Dependent objects **não** referenciam a entidade raiz (simplifica consistência).

---

## Estrutura do repositório
- `README.md` (este arquivo)
- `Program.cs` (implementação C# + runner de testes)
- (opcional) `Diagrama.txt` (diagrama ASCII)
- `RoteiroTestes.md` (roteiro + prints esperados)

---

## Como executar
1. Tenha o .NET SDK instalado.  
2. Crie um projeto console (opcional):  
   ```bash
   dotnet new console -n Trabalho5
3. Substitua o conteúdo de Program.cs pelo arquivo Program.cs deste repositório.

4. Execute:
   ```bash
   dotnet run --project Trabalho5

A saída do programa inclui os passos de teste (veja Roteiro de Testes).

