﻿using CommunityBot.Entities;
using CommunityBot.Features.GlobalAccounts;
using Discord.Commands;
using Discord.WebSocket;

namespace CommunityBot.Extensions
{
    public class MiunieCommandContext : SocketCommandContext
    {
        public GlobalUserAccount UserAccount { get; }
        
        public MiunieCommandContext(DiscordSocketClient client, SocketUserMessage msg) : base(client, msg)
        {
            if (User is null) { return; }
            UserAccount = GlobalUserAccounts.GetUserAccount(User);
            
            var commandUsedInformation = new CommandInformation(msg.Content, msg.CreatedAt.DateTime);
            
            UserAccount.AddCommandToHistory(commandUsedInformation);

            GlobalUserAccounts.SaveAccounts(UserAccount.Id);
        }
    }
}
