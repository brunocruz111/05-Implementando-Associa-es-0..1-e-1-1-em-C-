// Program.cs
using System;

namespace Trabalho5_Associacoes
{
    /// <summary>
    /// DadosBiometricos: dependente obrigatório (1:1) para Usuario.
    /// Todos os campos são validados no construtor.
    /// </summary>
    public sealed class DadosBiometricos
    {
        public string Tipo { get; }
        public DateTime CapturadoEm { get; }

        public DadosBiometricos(string tipo, DateTime capturadoEm)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Tipo da biometria é obrigatório.", nameof(tipo));
            if (capturadoEm > DateTime.UtcNow)
                throw new ArgumentException("Data de captura não pode ser futura.", nameof(capturadoEm));

            Tipo = tipo;
            CapturadoEm = capturadoEm;
        }

        public override string ToString() => $"DadosBiometricos[Tipo={Tipo}, CapturadoEm={CapturadoEm:yyyy-MM-ddTHH:mm:ssZ}]";
    }

    /// <summary>
    /// Usuario: entidade raiz que possui obrigatoriamente DadosBiometricos (1:1).
    /// A propriedade Biometria é somente leitura (não tem setter público).
    /// </summary>
    public sealed class Usuario
    {
        public string Nome { get; }
        public DadosBiometricos Biometria { get; }

        public Usuario(string nome, DadosBiometricos biometria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do usuário é obrigatório.", nameof(nome));
            Biometria = biometria ?? throw new ArgumentNullException(nameof(biometria), "DadosBiometricos obrigatório.");
            Nome = nome;
        }

        public override string ToString() => $"Usuario[Nome={Nome}] -> {Biometria}";
    }

    /// <summary>
    /// EnderecoPreferencial: dependente opcional (0..1) para Cliente.
    /// Campos validados no construtor.
    /// </summary>
    public sealed class EnderecoPreferencial
    {
        public string Rua { get; }
        public string Cidade { get; }

        public EnderecoPreferencial(string rua, string cidade)
        {
            if (string.IsNullOrWhiteSpace(rua))
                throw new ArgumentException("Rua é obrigatória.", nameof(rua));
            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException("Cidade é obrigatória.", nameof(cidade));
            Rua = rua;
            Cidade = cidade;
        }

        public override string ToString() => $"{Rua}, {Cidade}";
    }

    /// <summary>
    /// Cliente: entidade raiz que tem um EnderecoPreferencial opcional (0..1).
    /// Uso de métodos para definir/remover o endereço garante a invariante (no máximo 1).
    /// </summary>
    public sealed class Cliente
    {
        public string Nome { get; }
        public EnderecoPreferencial? EnderecoPreferencial { get; private set; }

        public Cliente(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do cliente é obrigatório.", nameof(nome));
            Nome = nome;
        }

        /// <summary>
        /// Define o endereco preferencial somente se ainda não houver um.
        /// Retorna true se a atribuição ocorreu, false caso já exista ou argumento nulo.
        /// </summary>
        public bool DefinirEnderecoPreferencial(EnderecoPreferencial endereco)
        {
            if (endereco == null) return false;
            if (EnderecoPreferencial != null) return false; // evita sobrescrita sem remoção
            EnderecoPreferencial = endereco;
            return true;
        }

        /// <summary>
        /// Remove o endereco preferencial atual (se existir). Retorna true se removido.
        /// </summary>
        public bool RemoverEnderecoPreferencial()
        {
            if (EnderecoPreferencial == null) return false;
            EnderecoPreferencial = null;
            return true;
        }

        public override string ToString() => $"Cliente[Nome={Nome}] EnderecoPref={(EnderecoPreferencial == null ? "(nenhum)" : EnderecoPreferencial.ToString())}";
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Trabalho 5 - Associações 1:1 e 0..1 ===\n");

            // === Passo 1: criar Usuario com DadosBiometricos (deve funcionar)
            Console.WriteLine("[1] Criar Usuario com DadosBiometricos (esperado: sucesso)");
            var biom = new DadosBiometricos("Digital", DateTime.UtcNow);
            var usuario = new Usuario("Alice Silva", biom);
            Console.WriteLine($" -> Criado: {usuario}");

            // === Passo 2: tentar criar Usuario sem DadosBiometricos (deve falhar)
            Console.WriteLine("\n[2] Tentar criar Usuario sem DadosBiometricos (esperado: falha)");
            try
            {
                var bad = new Usuario("Bob", null!);
                Console.WriteLine(" -> ERRO: devia ter lançado, criou: " + bad);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" -> Exceção esperada: " + ex.GetType().Name + " - " + ex.Message);
            }

            // === Passo 3: Cliente sem endereco (deve estar sem endereço)
            Console.WriteLine("\n[3] Criar Cliente sem EnderecoPreferencial (esperado: sem endereco)");
            var cliente = new Cliente("Empresa Exemplo");
            Console.WriteLine(" -> " + cliente);

            // === Passo 4: Definir EnderecoPreferencial (deve atribuir)
            Console.WriteLine("\n[4] Definir EnderecoPreferencial (esperado: atribuição bem sucedida)");
            var enderecoA = new EnderecoPreferencial("Rua Alfa, 100", "Medianeira");
            var atribuiu = cliente.DefinirEnderecoPreferencial(enderecoA);
            Console.WriteLine($" -> DefinirEnderecoPreferencial returned {atribuiu}; Cliente = {cliente}");

            // === Passo 5: Tentar sobrescrever Endereco sem remover (deve falhar)
            Console.WriteLine("\n[5] Tentar sobrescrever endereco sem remover (esperado: falha)");
            var enderecoB = new EnderecoPreferencial("Avenida Beta, 200", "Toledo");
            var tentou = cliente.DefinirEnderecoPreferencial(enderecoB);
            Console.WriteLine($" -> Tentativa sobrescrever returned {tentou}; Cliente = {cliente}");

            // Passo extra: remover e atribuir novo (bom para evidência adicional)
            Console.WriteLine("\n[6] Remover endereco e atribuir novo (esperado: remover=true, atribuir=true)");
            var removeu = cliente.RemoverEnderecoPreferencial();
            var atribuiu2 = cliente.DefinirEnderecoPreferencial(enderecoB);
            Console.WriteLine($" -> Remover returned {removeu}; Definir returned {atribuiu2}; Cliente = {cliente}");

            Console.WriteLine("\n=== FIM dos testes ===");
        }
    }
}
