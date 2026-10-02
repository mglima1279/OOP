using Project.Models;
using Project.Services;

namespace Project;

public class Program
{
    static void Main(string[] args)
    {
        var clinica = new ClinicaService();

        Console.WriteLine("=== SISTEMA DA CLÍNICA VIDA & SAÚDE ===\n");

        var p1 = new Paciente(1, "Maria Oliveira", "111.222.333-44", "(11) 98888-7777", new DateTime(1990, 5, 15));
        var p2 = new Paciente(2, "João Souza", "555.666.777-88", "(11) 97777-6666", new DateTime(1985, 10, 20));

        clinica.CadastrarPaciente(p1);
        clinica.CadastrarPaciente(p2);

        var m1 = new Medico(1, "Helena Rios", "123.456.789-00", "(11) 91111-2222", "CRM/SP 123456", "Cardiologia");
        var m2 = new Medico(2, "Roberto Alves", "987.654.321-11", "(11) 93333-4444", "CRM/SP 654321", "Ortopedia");

        clinica.CadastrarMedico(m1);
        clinica.CadastrarMedico(m2);

        Console.WriteLine("--- Cadastros Realizados ---");
        p1.ExibirFicha();
        m1.ExibirFicha();
        Console.WriteLine();

        Console.WriteLine("--- Agendamentos ---");
        clinica.AgendarConsulta(101, DateTime.Now.AddDays(2), 1, 1);
        clinica.AgendarConsulta(102, DateTime.Now.AddDays(3), 2, 2);

        clinica.ExibirRelatorioGeral();

        Console.WriteLine("\n--- Cancelamento de Consulta ---");
        var consultaParaCancelar = clinica.Consultas.FirstOrDefault(c => c.Codigo == 101);
        consultaParaCancelar?.Cancelar();

        clinica.ExibirRelatorioGeral();
    }
}