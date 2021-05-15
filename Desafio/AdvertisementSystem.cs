using System;
using System.Collections.Generic;

public class AdvertisementSystem
{  
    public List<Advertisement> advertisements;
    private Advertisement adToReport;

    public AdvertisementSystem()
    {
        advertisements = new List<Advertisement>();
    }

    public Advertisement CreateAD()
    {
        Console.WriteLine("Dê um nome para seu anúncio: ");
        string name = Console.ReadLine();

        Console.WriteLine("A quem esse anúncio pertence? ");
        string client = Console.ReadLine();

        Console.WriteLine("Qual será a data de início? ");
        DateTime startDate = CheckDate();

        Console.WriteLine("Qual será a data de fim? ");
        DateTime endDate = CheckDate();

        Console.WriteLine("Qual será o investimento diário deste anúncio? ");
        float dailyInvestment = float.Parse(Console.ReadLine());

        Advertisement myAd = new Advertisement(name, client,startDate, endDate,dailyInvestment);

        // Sempre que um anúncio for criado, ele tem que ser adicionado na lista.
        advertisements.Add(myAd);

        return myAd;
    }

        public DateTime CheckDate()
        {
            DateTime userDateTime;
            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {

            }
            else
            {
                Console.WriteLine("Você inseriu um valor inválido.");
            }
               
            return userDateTime;
        } 

        public void ProvideReport()
        {            
            // Solicita aqui nome do cliente
            Console.WriteLine("Digite seu nome para acessar o relatório:");
            string provideName = Console.ReadLine();

            //Passar por toda a lista
            // Para cada ad na lista de ads
            foreach (Advertisement currentAd in advertisements)
            {
               // Compara o nome do cliente com o ad.Client
                if(advertisements.Exists(x => x.Client == currentAd.Client))/*provideName == currentAd.Client*/
                { 
                    // Se for igual, referencia o advertisement para fornecer o relatório
                    adToReport = currentAd;  
                }
                else
                {
                    // Se não for igual, sinalizar que o anúncio não foi encontrado
                    Console.WriteLine("Não existe um anúncio para o cliente de nome: " + provideName);
                }
            }
            
            float investedAmount = InvestedAmount(adToReport);
           
            ADCalculator calculator = new ADCalculator();
            calculator.Calculate(investedAmount);
            Console.WriteLine("O total de visualizações do anúncio " + adToReport.AdName + " é de " + calculator.TotalViewers);
            Console.WriteLine("O total de cliques do anúncio " + adToReport.AdName + " é de " + calculator.TotalClicks);
            Console.WriteLine("O total de compartilhamentos do anúncio " + adToReport.AdName + " é de " + calculator.TotalShares);
        }
        
        public float InvestedAmount(Advertisement advertisement)
        {
            // Diminuir Data inicial com Data final, para obter quantidade de dias
            int totalDays = (advertisement.EndDate - advertisement.StartDate).Days;

            // Multiplicar o resultado em dias pelo total investido
            float totalInvestido = totalDays * advertisement.DailyInvestment;

            //Retornar valor 
            Console.WriteLine("O total investido do anúncio " + advertisement.AdName + " é de R$ " + totalInvestido);
            return totalInvestido; 
        }
}
 