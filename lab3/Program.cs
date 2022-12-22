using static System.Console;

const int Door = 1;
const int Head = 2;
const int Fireplace = 3;
const int Chest = 4;
const int NearHead = 5;
const int NearChest = 6;
const int NearFirePlace = 7;
const int NearDoor = 8;
const int Book = 9;
const int Mouth = 10;
const int CodeLock = 11;
const int KeyLock = 12;
const int BookCheck = 13;
const int CodeLockCheck = 14;
const int KeyLockCheck = 15;
const int DoorOpen = 16;

Story story = new StoryBuilder()
    .SetupStory("Вы открываете глаза и видете ранее не знакомое вам место, поднимаясь, вы ощущаете резкую боль в голове, кажется, вас оглушили каким-то тяжелым предметом.", "Вы сбежали", Door)
    .AddLocation(Door, "Вы стоите около двери")
    .AddLocation(Head, "Вы стоите около трофея оленьей головы")
    .AddLocation(Fireplace, "Вы стоите около камина")
    .AddLocation(Chest, "Вы стоите около сундука")
    .AddLocation(NearChest, "Вы приблизились к сундуку")
    .AddLocation(NearDoor, "Вы подошли ближе к двери")
    .AddLocation(NearFirePlace, "Вы подошли ближе к камину")
    .AddLocation(NearHead, "Вы приблизились к трофею")
    .AddLocation(Book, "Вы видете книгу")
    .AddLocation(Mouth, "Вы заметили кусочек бумаги у оленя во рту")
    .AddLocation(CodeLock, "Вы рассмартиваете замок на сундуке, для него нужен код")
    .AddLocation(KeyLock, "Вы рассматриваете замок на двери, для него нужен ключ")
    .AddLocation(BookCheck, "Вы начинаете листать книгу")
    .AddLocation(CodeLockCheck, "Вы набираете найденный ранее код")
    .AddLocation(KeyLockCheck, "Вы открываете дверь с помощью ключа")
    .AddLocation(DoorOpen, "Дверь открыта")
    ///
    .AddOption(Door, Head, "Подойти к трофею оленьей головы")
    .AddOption(Door, Fireplace, "Подойти к камину")
    .AddOption(Door, Chest, "Подойти к сундуку")
    .AddOption(Door, NearDoor, "Подойти к двери ближе и рассмортеть замок")
    .AddOption(NearDoor, KeyLock, "Попытаться открыть")  
    .AddOption(KeyLock,NearDoor, "Замок закрыт, не открыть. Вы отходите")  
    .AddOption(NearDoor, Door, "Отойти")  
    .AddOption(KeyLockCheck, DoorOpen, "Открыть дверь u сбежать")  

    ///
    .AddOption(Head, Door, "Подойти к двери")
    .AddOption(Head, Fireplace, "Подойти к камину")
    .AddOption(Head, Chest, "Подойти к сундуку")
    .AddOption(Head, NearHead, "Подойти к трофею поближе и рассмотреть")
    .AddOption(NearHead, Mouth, "Взять бумажку из рта")  
    .AddOption(NearHead, Head, "Отойти")  
    .AddOption(Mouth, BookCheck, "На бумажке написаны два числа, кажется, это страница и строчка книги. Время проверить")  
    ///
    .AddOption(Fireplace, Head, "Подойти к трофею оленьей головы")
    .AddOption(Fireplace, Chest, "Подойти к сундуку")
    .AddOption(Fireplace, Door, "Подойти к двери")
    .AddOption(Fireplace, NearFirePlace, "Подойти к камину поближе и рассмотреть то, что на нем лежит")
    .AddOption(NearFirePlace, Book, "Открыть книжку")
    .AddOption(NearFirePlace, Fireplace, "Отойти")
    .AddOption(BookCheck, CodeLockCheck, "Открыв нужную страницу и отсчитав нужную строчку, вы замечаете код, кажется он подходит для кодового замка. Бежим к нему")
    
    ///
    .AddOption(Chest, Head, "Подойти к трофею оленьей головы")
    .AddOption(Chest, Fireplace, "Подойти к камину")
    .AddOption(Chest, Door, "Подойти к двери")
    .AddOption(Chest, NearChest, "Подойти к сундуку ближе")
    .AddOption(NearChest, CodeLock, "Попытаться открыть")
    .AddOption(NearChest, Chest, "Отойти")
    .AddOption(CodeLockCheck, KeyLockCheck, "Вот оно! Сундук открылся и в нем был дверной ключ! Неужели вы скоро будете свободны? Вы идете к замку")

    .Build();

////////////
// engine //
////////////
Clear();
WriteLine(story.Intro);
while(true)
{
   Location loc=story.Locations.First(item=>item.Id==story.CurrentLocationId);
    WriteLine();
    WriteLine(loc.Description);
    for (int i=0; i<loc.Options.Count; i++) {
        WriteLine($"{i+1}. {loc.Options[i].Title}");
        if (story.CurrentLocationId==DoorOpen) goto Found;
    }
    for (int i=0; i==loc.Options.Count; i++) {
        if (i==loc.Options.Count)
            goto Found;
    }        
    int n=GetInt("Ваш выбор:", 1, loc.Options.Count)-1;
    loc.Options[n].Work!();
}
Found: WriteLine(story.Final);
int GetInt(string s, int min, int max) {
    int result=min;
    bool valid=false;
    do {
        Write(s);
        valid=int.TryParse(ReadLine(), out result);
    } while (!valid || result<min || result>max);
    return result;
}
