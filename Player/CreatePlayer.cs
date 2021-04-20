using System;
using MyRpgGame.Player.Specs;

namespace MyRpgGame.Player
{
    public class CreatePlayer
    {
        Character player;
        ListOfSpecs listOfSpecs = new ListOfSpecs();


        public Character NewPlayer()
        {
            var specs = listOfSpecs.GetSpecs();

            Console.Write("Введите имя вашего персонажа и нажмите Enter: ");
            string name = Console.ReadLine();
            Console.Clear();

            ChooseSpec:
            Console.Write("Выберите класс вашего персонажа выбрав соответствующую цифру и нажмите Enter: \n");
            for (int i = 0; i < specs.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {specs[i].SpecName}");
            }
            int chosenSpec = Convert.ToInt16(Console.ReadLine());

            if (chosenSpec < 0 || chosenSpec > specs.Count)
            {
                Console.Clear();
                goto ChooseSpec;
            }

            Console.Clear();

            player = new Character(name, specs[chosenSpec - 1]);

            Console.WriteLine("Приветствуем тебя " + player.Name);
            Console.WriteLine("В этой игре вы поочередно с врагом \"бросаете кубик\", значение могут выпасть от 1 до 10.");
            Console.WriteLine("У вас имеется 10 пустых ячеек соотвественно. Если значение кубика совпадает с пустой ячейкой, то вы наносити свой базовый урон.");
            Console.WriteLine("Если значение совпадает с ячейкой в которую вы поместили умение, то наносится урон от умения. Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();

            return player;
        }
    }
}
