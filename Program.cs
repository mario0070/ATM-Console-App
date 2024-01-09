class ATM {
    static void Main(string[] args){
        // Generic users
        List<CardHold> allUser = new List<CardHold>();
        allUser.Add(new("jamiu", 34400, 230.01, 1997));
        allUser.Add(new("ganiu", 10232, 912.71, 1111));
        allUser.Add(new("tboy", 56178, 810.20, 9999));
        allUser.Add(new("ayoka", 92217, 120.82, 0000));

        
        bool Retransact = true;
        bool correctAcct = true;
        CardHold cardHolder;
        int acctNum = 0;
        cardHolder = allUser.FirstOrDefault(x => x.acctNum == acctNum);

        System.Console.WriteLine("Welcome back");
        while(correctAcct){
            System.Console.Write("Enter your account number: ");
            try{
                acctNum = Convert.ToInt32( System.Console.ReadLine());
            }catch(Exception e){
                System.Console.WriteLine();
                System.Console.WriteLine(e.Message);
            }
            
            cardHolder = allUser.FirstOrDefault(x => x.acctNum == acctNum);
            System.Console.WriteLine($"Hi, {cardHolder.username}");
            Thread.Sleep(1000);
            System.Console.WriteLine();

            if(cardHolder != null){
                Retransact = true;
                correctAcct = false;
            }else{
                correctAcct = true;
                Retransact = false;
                System.Console.WriteLine();
                System.Console.WriteLine("Incorrect account number");
                System.Console.WriteLine();
            }
        }
       
        
        // Promp services
        while(Retransact){
                System.Console.WriteLine("Which service do you want today?");
                System.Console.WriteLine("Press 1 for withdraw: ");
                System.Console.WriteLine("Press 2 for Deposit: ");
                System.Console.WriteLine("Press 3 for Show balance: ");
                System.Console.Write("Choose from the options above: ");
                int services = 0;
                try{
                    services = Convert.ToInt32(System.Console.ReadLine());
                }catch(Exception e){
                    System.Console.WriteLine(e.Message);
                }
                
                CardHold cardHold = new("jamiu", 34400, 230.01, 1997);
                void Deposit(CardHold cardHold){
                    System.Console.Write("How much do you wanna deposit: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    double balance = cardHolder.GetBalance();
                    double opera = balance + amount;
                    cardHolder.SetBalance(opera);
                    System.Console.WriteLine("Please wait..........");
                    Thread.Sleep(2000);
                    System.Console.WriteLine();
                    System.Console.WriteLine($"You deposited {amount} and your new balance is ${cardHolder.GetBalance()}");
                }

                void Withdraw(CardHold cardHold){
                    System.Console.Write("How much do you wanna withdraw: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    double balance = cardHolder.GetBalance();
                    double opera = balance - amount;
                    cardHolder.SetBalance(opera);
                    System.Console.WriteLine("Please wait..........");
                    Thread.Sleep(2000);
                    System.Console.WriteLine();
                    System.Console.WriteLine($"You withdraw {amount} and your new balance is ${cardHolder.GetBalance()}");
                }

                void CheckBal(CardHold cardHold){
                    bool correctPin = true;
                    while(correctPin){
                        System.Console.Write("Enter your card pin: ");
                        int pin = Convert.ToInt32(System.Console.ReadLine());
                        int userPin = cardHolder.GetPin();
                        if(pin != userPin){
                            System.Console.WriteLine("Incorrect pin");
                            Thread.Sleep(1000);
                            correctPin = true;
                        }else{
                            correctPin = false;
                            double balance = cardHolder.GetBalance();
                            System.Console.WriteLine("Please wait..........");
                            Thread.Sleep(2000);
                            System.Console.WriteLine($"your balance is ${balance}");
                            Thread.Sleep(1000);
                        }
                        
                    }
                
                }

                static void None(){
                    System.Console.WriteLine("You enter invalid options");
                }

                
                switch(services){
                    case 1:
                        Withdraw(cardHold);
                        break;
                    case 2:
                        Deposit(cardHold);
                        break;
                    case 3:
                        CheckBal(cardHold);
                        break;
                    default:
                        None();
                        break;

                }

                // start new transaction or not
                System.Console.Write("Do you wanna start a new transaction Y/N: ");
                string ans = Console.ReadLine();

                switch (ans)
                {
                    case "Y":
                        Retransact = true;
                        break;
                    case "N":
                        Retransact = false;
                        break;                
                    default:
                        Retransact = false;
                        break;
                }
        }

       

        

        // System.Console.WriteLine(cardHold.GetAcctNum());
    }
}

class CardHold{
    public string username;
    public int acctNum;
    public double balance;
    public int pin;

    public CardHold(string username, int acctNum, double balance, int pin){
        this.username = username;
        this.acctNum = acctNum;
        this.balance = balance;
        this.pin = pin;
    }

    public string GetUsername(){
        return username;
    }


    public double GetBalance(){
        return balance;
    }

    public void SetBalance(double Userbalance){
        balance = Userbalance;
    }

    public int GetAcctNum(){
        return acctNum;
    }

    public void SetAcctNum(int UseracctNum){
        acctNum = UseracctNum;
    }

    public int GetPin(){
        return pin;
    }
}