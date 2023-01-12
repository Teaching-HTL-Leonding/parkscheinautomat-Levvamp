// See https://aka.ms/new-console-template for more information
double coins = 0.00;
int minutes = 0;
int hours = 0;
bool parkingTime = false;
PrintWelcome();
EnterCoins();
PrintParkingTime();
PrintDonation();

void PrintWelcome(){
    Console.WriteLine("Hallo");
    Console.WriteLine("Zulässige Münzen: 50 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    Console.WriteLine("Parkschein drucken mit d oder D");
}

void EnterCoins()
{
    bool isDone = false;

    do
    {
        Console.Write("Bitte werfen Sie eine Münze ein: ");
        string input = Console.ReadLine()!;

        if (input == "d" || input == "D"){
            if (coins > 0.5){
                isDone = true;
            }
            else
            {
                Console.WriteLine("Mindesteinwurf 50 Cent");
            }
        }
        else
        {
            if (input == "5" || input == "10" || input == "20" || input == "50" || input == "1" || input == "2")
            {
                double coin = double.Parse(input);
                if(coin == 1)
                {
                    coins += 1;
                    AddParkingTime(coin);
                } 
                else if(coin == 2) 
                {
                    coins += 2;
                    AddParkingTime(coin);
                }
                else 
                {
                    AddParkingTime(coin);
                    coins += coin / 100;
                }
                Console.WriteLine($"Ihre Parkzeit bisher: {hours}:{minutes:00}");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe!");
            }
        }
    } while (!isDone || !parkingTime);
}

void AddParkingTime(double coin){
    switch (coin)
    {
        case 1:
            hours++;
            break;
        case 2:
            hours += 2;
            break;
        case 5:
            minutes += 3;
            break;
        case 10:
            minutes += 6;
            break;
        case 20:
            minutes += 12;
            break;
        case 50:
            minutes += 30;
            break;
        default:
        break;
    }
    if(minutes >= 60) 
    {
        minutes -= 60;
        hours++;
    }
    if(hours > 1 && minutes > 30 || hours > 1) {
        PrintParkingTime();
        parkingTime = true;
    }
}

void PrintParkingTime()
{
    Console.WriteLine($"Your current parking time is {hours}:{minutes:00}");
}

void PrintDonation()
{
    int euro = 0;
    double cents = 0;
    if(coins >= 1.50)
    {
        coins -= 1.50;
        do 
        {
            euro += 1;
            coins -= 1;
        }while(coins >= 1);
        cents = (coins * 100);
    }
    Console.WriteLine($"Danke für Ihre Spende {euro} Euro {cents} cents");
    
}