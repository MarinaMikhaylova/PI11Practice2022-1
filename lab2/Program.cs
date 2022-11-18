using System;

namespace myquestroom
{
    class Program
    {
        static int GetInt(string s, int min, int max)
        {
            int result = min;
            bool valid = false;
            do
            {
                Console.WriteLine(s);
                valid = int.TryParse(Console.ReadLine(), out result);

            }
            while (!valid || result < min || result > max);

            return result;
        }
        static void Main(string[] args)
        {
            //констаны
            const int Door = 1;
            const int Head = 2;
            const int Fireplace = 3;
            const int Chest = 4;
            //переменные
            Random rnd = new Random();
            int location = Door;
            int chest_code = rnd.Next(100, 1000);   // пароль от сейфа
            int book_codepage = rnd.Next(5, 256); 
            int book_codeline = rnd.Next(1, 70);
            bool photo_look = false;
            bool chest_open = false;
            bool key_get = false;
            bool head_look = false;
            bool book_look = false;
            bool paper_taken = false;
            bool door_unlocked = false;
            bool book_codetaken = false;

            //ввод
            Console.Clear();
            Console.WriteLine("...");
            Console.WriteLine("Вы открываете глаза и видете ранее не знакомое вам место, поднимаясь, вы ощущаете резкую боль в голове, кажется, вас оглушили каким-то тяжелым предметом.");
            Console.WriteLine("Вы еле как встаете и начинаете осматриваться. Вы находитесь в небольшой комнате, которую освещает теплым светом искусно сделанный камин, вы замечаете, что на нем стоит чья-то фотография, а рядом с ней лежит книга.");
            Console.WriteLine("Насмотревшись на огонь, вы смотрите вправо и чуть не падает от испуга!! На вас смотрит охотничий трофей в виде головы оленя.");
            Console.WriteLine("Успокоившись, вы натыкаетесь на маленький сундучок, стоящий на полу. На нем висит кодовый замок.");
            Console.WriteLine("Развернувшись, вы осмотрели последнее ранее не изученное место, прямо за вами стоит старая изящная, но прочная дверь. Вы дергаете за ее ручку, но она не поддается. Наклонившись вниз, вы видете замок.");
            Console.WriteLine("Кажется, вы здесь заперты, но еще рано сдаваться, Выбирайтесь!");
            Console.WriteLine();

            //основной цикл
            while (true)
            {
                Console.WriteLine();

                if (location == Door)
                {
                    //описание и вывод доступных действий
                    Console.WriteLine();
                    Console.WriteLine("Вы стоите около двери. ");
                    Console.WriteLine();
                    Console.WriteLine("1) подойти к трофею");
                    Console.WriteLine("2) подойти к камину");
                    Console.WriteLine("3) подойти к сундуку");
                    if (key_get)
                        Console.WriteLine("4) отпереть замок");
                    else
                        Console.WriteLine("4) попытаться открыть.");

                    //выбор действий
                    int n = GetInt("Ваш выбор: ", 1, 4);


                    //обрабоотка действий
                    if (n == 1)
                    {
                        location = Head;
                    }
                    else if (n == 2)
                    {
                        location = Fireplace;

                    }
                    else if (n == 3)
                    {
                        location = Chest;

                    }
                    else if (n == 4)
                    {
                        if (door_unlocked)
                        {
                            //дверь отперта
                            break;
                        }
                        else
                        {
                            //дверь заперта
                            if (key_get)
                            {
                                Console.WriteLine();
                                door_unlocked = true;
                                Console.WriteLine("Вы отпираете дверь найденным вами ранее ключом.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Вы не может открыть замок без ключа.");
                            }
                        }
                    }
                }
                else if (location == Head)
                {
                    //описание и вывод доступных действий

                    if (head_look)
                    {
                        //голова на стене наблюдает
                        Console.WriteLine();
                        Console.WriteLine("С небольшой непрязнью, вы решаете осмотреть голову ещё раз.");
                        
                    }
                    else if (paper_taken)
                    {
                        //бумажка уже есть
                        Console.WriteLine();
                        Console.WriteLine("Вы больше ничего не находите, сколько ни смотрите.");
                    }
                    else
                    {
                        //сейф открыт и пуст
                        Console.WriteLine();
                        Console.WriteLine("Вы смотрите в пустые глаза оленя и вам начинает казаться, что он тоже за вами наблюдает. Вам становится не по себе и вы отходите.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Вы стоите около трофея. ");
                    Console.WriteLine();
                    Console.WriteLine("1) Подойти к двери");
                    Console.WriteLine("2) Подойти к камину");
                    Console.WriteLine("3) Подойти к сундуку");
                    if (head_look) Console.WriteLine("4) Осмотреть трофей");
                    else Console.WriteLine("4) Подойти ближе к трофею");
                    //выбор действий
                    int n = GetInt("Ваш выбор:", 1, 4);


                    //обработка действий
                    if (n == 1)
                    {
                        location = Door;
                    }
                    else if (n == 2)
                    {
                        location = Fireplace;

                    }
                    else if (n == 3)
                    {
                        location = Chest;

                    }
                    else if(n == 4)
                    {
                        if(paper_taken)
                            Console.WriteLine("Вы уже всё здесь осмотрели.");
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Присмотревшись, вы видете в его рту что-то белое. Приложив немного усилий, вы достаете заинтересовавшую вас вещь. Это оказался кусочек бумаги, на котором было написано {book_codepage}");
                            Console.WriteLine($"Повернув бумажку вы обнаружили еще одну надпись {book_codeline}");
                            paper_taken = true;
                        }
                    }

                }
                else if (location == Fireplace)
                {
                    //описание и вывод
                    Console.WriteLine();
                    Console.WriteLine("Вы стоите около камина.");
                    Console.WriteLine("");
                    Console.WriteLine("1) подойти к двери.");
                    Console.WriteLine("2) подойти к трофею.");
                    Console.WriteLine("3) подойти к сундуку.");
                    if(!photo_look && !book_look ||!photo_look && book_look || photo_look && !book_look) Console.WriteLine("4) рассмотреть, то что лежит на камине.");
                    else Console.WriteLine("4) Рассмотреть вещи на камине ещё раз.");
                    //выбор действий
                    int n = GetInt("Ваш выбор:", 1, 4);

                    //обработка действий
                    if (n == 1)
                        location = Door;
                    else if (n == 2)
                        location = Head;
                    else if (n == 3)
                        location = Chest;
                    else if (n == 4)
                    {
                        if(book_codetaken && book_look)
                            Console.WriteLine("Вы уже все осмотрели.");
                        else 
                        {
                            Console.WriteLine();
                            Console.WriteLine("Немного посмотрев на них, вы решаете рассмотреть одно из них");
                            Console.WriteLine("1) книгу");
                            Console.WriteLine("2) фотографию");
                            int m = GetInt("Что рассматриваем:", 1, 2);

                            if(m == 1)
                            {

                                if(paper_taken)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Вы выбрали книгу, ранее найденная вами бумажка уже дала вам намек на неё, настало время проверить.");
                                    book_look=true;
                                    int x = GetInt("Открыть страницу: ", 5, 255);
                                    if (x == book_codepage)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Так, кажется, страница верная, теперь второе число");
                                        int y = GetInt("Отсчитать строчку: ", 1, 69);
                                        if (y == book_codeline)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine($"Вы начали читать отсчитанную строчку: '.. И вот в город ворвалось {chest_code} головорезов ..'");
                                            Console.WriteLine("Кажется, это число здесь не просто так..");
                                            book_codetaken = true;
                                        }
                                        else Console.WriteLine("Кажется, что-то не то..");
                                            
                                    }
                                    else Console.WriteLine("Странно.. Кажется, вы открыли не ту страницу. Попробуйте еще раз.");
                                }
                                    
                                else if(!paper_taken)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Вы бесцельно листаете потрепанную книжку, однако ничего путного не находите.");
                                    book_look=true;
                                }

                            }
                            if(m==2)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Вы берёте в руки фотографию. На ней запечатлён охотник с добычей в руках - головой оленя. Вам кажется, что стоит вернуться к трофею");
                                head_look=true;
                                photo_look=true;
                            }

                        }
                    }
                }
                else if (location == Chest)
                {
                    //описание и вывод
                    Console.WriteLine();
                    Console.WriteLine("Вы стоите около сундука.");
                    Console.WriteLine("");
                    Console.WriteLine("1) подойти к двери ");
                    Console.WriteLine("2) подойти к трофею");
                    Console.WriteLine("3) подойти к камину");
                    Console.WriteLine("4) рассмотреть сундук");

                    //выбор действий
                    int n = GetInt("Ваш выбор", 1, 4);

                    //обработка действий
                    if (n == 1)
                        location = Door;
                    else if (n == 2)
                        location = Head;
                    else if (n == 3)
                        location = Fireplace;
                    else if (n == 4)
                    {
                        if(!chest_open)
                        {
                            //ввести код
                            Console.WriteLine();
                            int x = GetInt("Введите код |***|:", 100, 999);
                            if (x == chest_code)
                            {
                                Console.WriteLine();
                                chest_open = true;
                                Console.WriteLine("Щёлк! Замок открылся!");
                                key_get= true;
                                Console.WriteLine("В сундуке был дверной ключ, теперь вы, наконец, можете выбраться!");
                            }
                            else
                                Console.WriteLine("Странно.. Кажется вы что-то неправильно набрали. Попробуйте еще раз.");
                        }
                        else if (key_get)
                        {
                            //сейф открыт там нет ключа
                            Console.WriteLine();
                            Console.WriteLine("Зачем вы снова вернулись к сундуку? Ваш ключ к свободе уже у вас в руках.");  
                        }
                        {

                        }
                    }
                }
            }
            //поздравление
            Console.WriteLine();
            Console.WriteLine("Вы смогли выбраться из комнаты!");
        }
    }
}
