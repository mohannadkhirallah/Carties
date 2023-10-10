using Contracts;
using MassTransit;

namespace AuctionService;
public class AuctionCreatedFaultConsumer : IConsumer<Fault<AuctionCreated>>

{
    public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
    {
        Console.WriteLine("--> Consuming faulty creation");
        
        var exce = context.Message.Exceptions.First();
        if(exce.ExceptionType == "System.ArgumentException") 
        {
            context.Message.Message.Model ="Foobar";
            await context.Publish(context.Message.Message);
        }
        else {
            Console.WriteLine("Not an argument exception - update error dashbaord somewhere");
        }
    }
}
