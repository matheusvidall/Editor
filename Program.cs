using System;
using System.IO;
namespace Editor;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu() ///Configura todo o menu
    {
        Console.Clear();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Abrir arquivo");
        Console.WriteLine("2 - Criar novo arquivo");
        Console.WriteLine("0 - Sair");
        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 0:
                Console.WriteLine("Obrigado por utilizar nosso editor!!");
                Thread.Sleep(1000);
                System.Environment.Exit(0); break;

            case 1: Abrir(); break;
            case 2: Editar(); break;
            default: Menu(); break;
        }
    }

    static void Abrir()
    {
        Console.Clear();
        Console.WriteLine("Qual o caminho do arquivo? ");// Implementação da função Abrir() se necessário
        string path = Console.ReadLine();
        using (var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();
            Console.WriteLine(text);
            Thread.Sleep(3000);
            Console.WriteLine("Obrigado e até a proxima!");
            Console.Clear();
            Menu();
        }

    }

    static void Editar()
    {
        Console.Clear();
        Console.WriteLine("----------------------");
        Console.WriteLine("Digite seu texto: (ESC para sair)");
        Console.WriteLine("----------------------");
        string text = "";

        while (true) ///enquanto usuario não teclar ESC segue firme e forte kk
        {
            var KeyInfo = Console.ReadKey(intercept: true);
            if (KeyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }
            else
            {
                Console.Write(KeyInfo.KeyChar);
                text += KeyInfo.KeyChar;
            }
            ///Tentei usando While/do mas não funcionou como esperado alterei para for and else
        }

        Salvar(text); /// Aqui passamos o texto para a função Salvar
    }
    static void Encerramento() ///eu poderia criar esse encerramento dentro da função salvar, mas quis fazer uma firula para fins educacionais
    {
        Console.WriteLine("1 - Sim");
        Console.WriteLine("2 - Não");
    }
    static void Salvar(string text) ///linha para caminho e salvamento do txt
    {
        Console.Clear();
        Console.WriteLine("Qual caminho para salvar o arquivo?");
        var path = Console.ReadLine();
        using (var file = new StreamWriter(path))  ///salvamento do txt
        {
            file.Write(text);
        }
        Console.WriteLine($"Arquivo {path} salvo com sucesso!!");
        Console.Clear();
        Console.WriteLine("Obrigado, até a proxima!");
        Thread.Sleep(1000);
        Console.WriteLine("Deseja rever nosso menu?");
        short option = short.Parse(Console.ReadLine());
        switch (option)
        {
            case 1: Menu(); break;
            case 2: System.Environment.Exit(0); break;
        }

    }

}