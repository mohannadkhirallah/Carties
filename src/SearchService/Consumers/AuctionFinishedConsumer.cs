﻿using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService;
public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
{
    public async Task Consume(ConsumeContext<AuctionFinished> context)
    {
        Console.WriteLine(" --> Consuming Auction Finished");
        var auction  = await DB.Find<Item>().OneAsync(context.Message.AuctionId);
        
        if(context.Message.Itemsold)
        {
            auction.Winner = context.Message.Winner;
            auction.SoldAmount = (int) context.Message.Amount;
        }
        auction.Status ="Finished";
        await auction.SaveAsync();
       
    }
}
