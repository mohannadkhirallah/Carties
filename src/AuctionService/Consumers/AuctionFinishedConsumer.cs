using Contracts;
using MassTransit;

namespace AuctionService;
public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
{
    private readonly AuctionDbContext _context;

    public AuctionFinishedConsumer(AuctionDbContext context)
    {
        _context = context;
    }
    public async Task Consume(ConsumeContext<AuctionFinished> context)
    {
        Console.WriteLine("---> Consuming Auction Finished");
        var auction =  await _context.Auctions.FindAsync(context.Message.AuctionId);
        if(context.Message.Itemsold)
        {
            auction.Winner = context.Message.Winner;
            auction.SoldAmount = context.Message.Amount;
        }
        auction.Status = auction.SoldAmount > auction.ReservePrice ? Status.Finished: Status.ReserveNotMet;
        
        await _context.SaveChangesAsync();
    }
}
