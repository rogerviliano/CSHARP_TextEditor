// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;

Menu();


static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que deseja fazer?\n1- Abrir Arquivo\n2-Criar\n0-Sair");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: Environment.Exit(0); break;
        case 1: Open(); break;
        case 2: Create(); break;
        default: Menu(); break;

    }

}

static void Open()
{
    Console.Clear();
    Console.WriteLine("Digite o caminho do arquivo para abrir:");
    string path = Console.ReadLine();
    //semelhante ao abrir, usar o 'using' para garantir abertura e fechamento
    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();//lê arquivo até o final
        foreach (char e in text)
        {
            Console.Write(e);// corrigir problema com uso de culture para caracteres acentuados
            Thread.Sleep(180);
        }
    }
    Console.WriteLine("");// pula uma linha
    Console.ReadLine(); // aguarda tecla para retornar ao menu
    Menu();
}

static void Create() //Editar arquivo de texto
{
    Console.Clear();
    Console.WriteLine("Digite seu texto - (ESC para Sair)");
    Console.WriteLine("---------------------------------)");
    string text = "";

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine; //captura e contatena a quebra de linha

    } while (Console.ReadKey().Key != ConsoleKey.Escape); // condição de saída do Do/While comparando as teclas com a tecla ESC

    Save(text);
}

static void Save(string text)
{
    Console.Clear();
    Console.WriteLine(" Qual caminho para salvar o arquivo?");
    var path = Console.ReadLine();

    //new StreamWriter >> Abre arquivo
    using (var file = new StreamWriter(path)) //abre e fecha o objeto passado como parametro..aqui no caso um array de bites
    {
        file.Write(text);
    }
    Console.WriteLine($"Arquivo salvo com sucesso em {path}");
    Console.ReadKey();
    Menu();
}