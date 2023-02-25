
using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();
//await AddNewRecords();
QueryStreaming();


void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Name = "Disney",
        Url = "https://www.disney.com"
    };

    dbContext!.Streamers!.Add(streamer);
    await dbContext.SaveChangesAsync();

    var movies = new List<Video>{
        new Video{
            Name = "La Cenicienta",
            StreamerId = streamer.Id
        },
            new Video{
            Name = "101 Dalmatas",
            StreamerId = streamer.Id
        },
            new Video{
            Name = "O Corcunda de Notredame",
            StreamerId = streamer.Id
        },
            new Video{
            Name = "Star Wars",
            StreamerId = streamer.Id
        },
    };

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}
