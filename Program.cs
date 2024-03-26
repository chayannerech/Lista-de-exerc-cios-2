namespace Lista_de_exercícios_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[] valores = [-5, 3, 4, 5, 9, 6, 10, -2, 11, 1, 2, 6, 7, 8, 0, -6];
                int[] emOrdem = ColocaOrdem(valores);
                string opcao = MostrarMenu(valores);
                if (OpcaoInvalida(opcao)) Console.WriteLine("\nOpção inválida :( Por favor, tente novamente.");
                if (SaidaSelecionada(opcao)) break;
                else RealizarAcao(valores, emOrdem, opcao);
                if (DeveContinuar()) break;
            }
        }

        static void mostrarSequencia(int[] valores)
        {
            for (int i = 0; i < valores.Length; i++)
            {
                Console.Write(valores[i]);
                if (i < valores.Length - 1) Console.Write(", ");
            }
        }
        static int[] ColocaOrdem(int[] valores)
        {
            int[] emOrdem = new int[valores.Length];
            Array.Copy(valores, emOrdem, valores.Length);
            Array.Sort(emOrdem);
            return emOrdem;
        }
        static string MostrarMenu(int[] valores)
        {
            Console.Clear();
            Console.Write("Lista de exercícios 2\n\nA sequência é: ");

            mostrarSequencia(valores);

            Console.WriteLine("\n\nO que deseja fazer?\n\n1- encontrar o maior valor\n2- encontrar o menor valor\n3- encontrar o valor médio\n4- encontrar os três maiores valores\n5- encontrar os valores negativos\n6- mostrar na tela os valores\n7- remover um item da sequência\n8- sair\n");
            return Console.ReadLine();
        }
        static bool SaidaSelecionada(string opcao)
        {
            return opcao == "8";
        }
        static bool OpcaoInvalida(string opcao)
        {
            bool opcaoInvalida = opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6" && opcao != "7" && opcao != "8";
            return opcaoInvalida;
        }
                private static void RealizarAcao(int[] valores, int[] emOrdem, string opcao)
        {
            switch (opcao)
            {
                case "1":
                    Console.WriteLine($"\nO maior número é: {emOrdem[emOrdem.Length - 1]}");
                    break;

                case "2":
                    Console.WriteLine($"\nO menor número é: {emOrdem[0]}");
                    break;

                case "3":
                    string medio = "";
                    decimal soma = 0;
                    do
                    {
                        Console.WriteLine("\nVocê deseja os valores médios [1], os números do meio [2] ou a média dos valores [3]?");
                        medio = Console.ReadLine();

                        if (medio == "1") Console.WriteLine($"\nOs valores médios são: {emOrdem[(emOrdem.Length / 2) - 1]} e {emOrdem[emOrdem.Length / 2]}");
                        else if (medio == "2") Console.WriteLine($"\nOs números do meio são: {valores[(valores.Length / 2) - 1]} e {valores[valores.Length / 2]}");
                        else if (medio == "3")
                        {
                            for (int i = 0; i < valores.Length; i++) soma = soma + valores[i];
                            Console.WriteLine("\nA média dos valores é: " + Math.Round(soma / valores.Length, 2));
                        }
                        else Console.WriteLine("Valor inválido, por favor, tente novamente");
                    }
                    while (medio != "1" && medio != "2" && medio != "3");
                    break;

                case "4":
                    Console.WriteLine($"\nOs três maiores valores são: {emOrdem[emOrdem.Length - 1]}, {emOrdem[emOrdem.Length - 2]}, {emOrdem[emOrdem.Length - 3]}");
                    break;

                case "5":
                    string negativos = "";
                    for (int i = 0; i < valores.Length; i++)
                    {
                        if (valores[i] < 0) negativos = $"{negativos} {Convert.ToString(valores[i])}";
                    }
                    Console.WriteLine($"\nOs valores negativos são:{negativos}");
                    break;

                case "6":
                    string ordem = "";
                    do
                    {
                        Console.WriteLine("\nVocê deseja ver a sequência na ordem atual [1], na ordem crescente [2] ou decrescente [3]?");
                        ordem = Console.ReadLine();
                        if (ordem == "1") mostrarSequencia(valores);
                        else if (ordem == "2") mostrarSequencia(emOrdem);
                        else if (ordem == "3")
                        {
                            Array.Reverse(emOrdem);
                            mostrarSequencia(emOrdem);
                        }
                        else Console.WriteLine("Valor inválido, por favor, tente novamente");
                    }
                    while (ordem != "1" && ordem != "2" && ordem != "3");
                    break;

                case "7":
                    Console.WriteLine($"\nQual valor você quer remover?");
                    int remover = Convert.ToInt32(Console.ReadLine());

                    var removerDoArray = valores.ToList();
                    removerDoArray.RemoveAll(x => x == remover);

                    for (int i = 0; i < valores.Length; i++)
                    {
                        if (i < removerDoArray.Count) Console.Write(removerDoArray[i] + " ");
                    }

                    break;
            }
        }
static bool DeveContinuar()
        {
            Console.WriteLine("\n\nDeseja repetir? [S/N]");
            string continuar = Console.ReadLine();
            return continuar == "N" || continuar == "n";
        }
    }
}
