using Bogus;
using GenerateFakeDataSample;
using System.Text.Json;

Randomizer.Seed = new Random(10);

var customerData = new Faker<Customer>()

    .RuleFor(x => x.Name, x => x.Person.FullName)
    .RuleFor(x => x.Email, x => x.Person.Email)
    .RuleFor(x => x.Phone, x => x.Person.Phone)
    .RuleFor(x => x.AddressLine, x => x.Address.StreetAddress())
    .RuleFor(x => x.City, x => x.Address.City())
    .RuleFor(x => x.Country, x => x.Address.Country())
    .RuleFor(x => x.PostCode, x => x.Address.ZipCode());

for (int i = 0; i < 10; i++)
{
    var text = JsonSerializer.Serialize(customerData.Generate());
    Console.WriteLine(text);
}
