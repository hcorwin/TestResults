using ResultsApi.Models;
using ResultsApi.Services;
using System.Drawing.Imaging;
using System.Text;
using SixLabors.ImageSharp.Formats.Png;


namespace ResultsApi.Data
{
    public static class SeedData
    {
        public static async Task Seed(this ResultsContext context)
        {
            if (!context.Results.Any())
            {
                var results = new List<Result>
                {
                    new()
                    {
                        Student = "Holden",
                        Subject = "Math",
                        Grade = "A",
                        Score = 96
                    },
                    new()
                    {
                        Student = "Nick",
                        Subject = "English",
                        Grade = "A",
                        Score = 92
                    },
                    new()
                    {
                        Student = "Ryan",
                        Subject = "Science",
                        Grade = "C",
                        Score = 74
                    },
                    new()
                    {
                        Student = "Kyle",
                        Subject = "History",
                        Grade = "B",
                        Score = 87
                    }
                };

                context.Results.AddRange(results);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var encryption = new PasswordEncryptionService();
                var salt = encryption.GenerateSalt();

                var user = new User
                {
                    Username = "test@test.com",
                    Password = encryption.HashPassword("test", salt),
                    Salt = Convert.ToBase64String(salt)
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            if (!context.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new()
                    {
                        Title = "Lord of the Rings Trilogy",
                        Description = "The Lord of the Rings is the saga of a group of sometimes reluctant heroes who set forth to save their world from" +
                                      " consummate evil. Its many worlds and creatures were drawn from Tolkien’s extensive knowledge of philology" +
                                      " and folklore. At 33, the age of adulthood among hobbits, Frodo Baggins receives a magic Ring of Invisibility from his" +
                                      " uncle Bilbo. Frodo, a Christlike figure, learns that the ring has the power to control the entire world and, he discovers," +
                                      " to corrupt its owner. A fellowship of hobbits, elves, dwarfs, and men is formed to destroy the ring by casting it into the" +
                                      " volcanic fires of the Crack of Doom, where it was forged. They are opposed on their harrowing mission by",
                        Price = 50,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/lotr.jpg"))),
                        VideoId = "https://www.youtube.com/embed/cnf4h5HT4dc?si=j9mMiPXfEqAO72fE"
                    },
                    new()
                    {
                        Title = "Harry Potter full Set",
                        Description = "Harry Potter is a series of seven fantasy novels written by British author J. K. Rowling. The novels chronicle the lives of a" +
                                      " young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all of whom are students at Hogwarts School of" +
                                      " Witchcraft and Wizardry. The main story arc concerns Harry's conflict with Lord Voldemort, a dark wizard who intends to become " +
                                      "immortal, overthrow the wizard governing body known as the Ministry of Magic, and subjugate all wizards and Muggles " +
                                      "(non-magical people).The series was originally published in English by Bloomsbury in the United Kingdom and " +
                                      "Scholastic Press in the United States. A series of many genres, including fantasy, drama, coming-of-age fiction, and the " +
                                      "British school story (which includes elements of mystery, thriller, adventure, horror, and romance), the world of Harry " +
                                      "Potter explores numerous themes and includes many cultural meanings and references.[1] Major themes in the series include" +
                                      " prejudice, corruption, madness, and death",
                        Price = 80,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/HarryPotter.png"))),
                        VideoId = "https://www.youtube.com/embed/LYKxhbcZrN8?si=1XMzQOkyQsR7EbX7"
                    },
                    new ()
                    {
                        Title = "Inception",
                        Description = "Dom Cobb (Leonardo DiCaprio) is a thief with the rare ability to enter people's dreams and steal their secrets from their" +
                                      " subconscious. His skill has made him a hot commodity in the world of corporate espionage but has also cost him everything" +
                                      " he loves. Cobb gets a chance at redemption when he is offered a seemingly impossible task: Plant an idea in someone's mind." +
                                      " If he succeeds, it will be the perfect crime, but a dangerous enemy anticipates Cobb's every move.",
                        Price = 15,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/inception.png"))),
                        VideoId = "https://www.youtube.com/embed/YoHD9XEInc0?si=6R2BqWbf2lsdAekj"
                    },
                    new()
                    {
                        Title = "Interstellar",
                        Description = "Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew" +
                                      " McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian" +
                                      " future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel" +
                                      " through a wormhole near Saturn in search of a new home for humankind.Brothers Christopher and Jonathan Nolan wrote" +
                                      " the screenplay, which had its origins in a script Jonathan developed in 2007 and was originally set to be directed by Steven" +
                                      " Spielberg. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted" +
                                      " as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it " +
                                      "on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place" +
                                      " in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature effects, and the company Double Negative" +
                                      " created additional digital effects.",
                        Price = 12,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/interstellar.png"))),
                        VideoId = "https://www.youtube.com/embed/2LqzF5WauAw?si=z8Z2SqAbakA3rhU3"
                    },
                    new()
                    {
                        Title = "The Shawshank Redemption",
                        Description = "The Shawshank Redemption is a 1994 American prison drama film written and directed by Frank Darabont, based on the 1982 Stephen King" +
                                      " novella Rita Hayworth and Shawshank Redemption. The film tells the story of banker Andy Dufresne (Tim Robbins), who is sentenced " +
                                      "to life in Shawshank State Penitentiary for the murders of his wife and her lover, despite his claims of innocence. Over the following" +
                                      " two decades, he befriends a fellow prisoner, contraband smuggler Ellis \"Red\" Redding (Morgan Freeman), and becomes instrumental" +
                                      " in a money laundering operation led by the prison warden Samuel Norton (Bob Gunton). William Sadler, Clancy Brown, Gil Bellows," +
                                      " and James Whitmore appear in supporting roles.",
                        Price = 18,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/shawshank.jpg"))),
                        VideoId = "https://www.youtube.com/embed/PLl99DlL6b4?si=-92zBCdQAurLw9zD"
                    },
                    new()
                    {
                        Title = "Bladerunner 2049",
                        Description = "Blade Runner 2049 is a 2017 American epic neo-noir science fiction film directed by Denis Villeneuve and written by Hampton Fancher" +
                                      " and Michael Green.[10] A sequel to the 1982 film Blade Runner, the film stars Ryan Gosling and Harrison Ford, with Ana de Armas" +
                                      ", Sylvia Hoeks, Robin Wright, Mackenzie Davis, Dave Bautista, and Jared Leto in supporting roles. Ford and Edward James Olmos" +
                                      " reprise their roles from the original film. Gosling plays K, a Nexus-9 replicant \"blade runner\" who uncovers a secret that" +
                                      " threatens to destabilize society and the course of civilization.",
                        Price = 20,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/bladerunner.png"))),
                        VideoId = "https://www.youtube.com/embed/gCcx85zbxz4?si=VTCiK0heN91fA7G9"
                    },
                    new()
                    {
                        Title = "Prisoners",
                        Description = "Prisoners is a 2013 American thriller film directed by Denis Villeneuve and written by Aaron Guzikowski. The film has an ensemble" +
                                      " cast including Hugh Jackman, Jake Gyllenhaal, Viola Davis, Maria Bello, Terrence Howard, Melissa Leo, and Paul Dano. The" +
                                      " film follows the abduction of two young girls in Pennsylvania and the subsequent search for the perpetrator by the police. After" +
                                      " police arrest a young suspect and release him, the father of one of the daughters takes matters into his own hands. The film was" +
                                      " a financial and critical success, grossing US$122 million worldwide. It was chosen by the National Board of Review as one of the" +
                                      " top ten films of 2013, and at the 86th Academy Awards, Roger Deakins was nominated for Best Cinematography.",
                        Price = 17,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/prisoners.png"))),
                        VideoId = "https://www.youtube.com/embed/bpXfcTF6iVk?si=y8F5x5_EVZaQsnVS"
                    },
                    new()
                    {
                        Title = "The Nice Guys",
                        Description = "The Nice Guys is a 2016 American neo-noir buddy action comedy film directed and co-written (alongside Anthony Bagarozzi) by" +
                                      " Shane Black, produced by Joel Silver, and starring Russell Crowe and Ryan Gosling in the title roles with Angourie Rice," +
                                      " Matt Bomer, Margaret Qualley, Keith David and Kim Basinger in supporting roles. Set in 1977 Los Angeles, the film focuses" +
                                      " on private eye Holland March (Gosling) and tough enforcer for hire Jackson Healy (Crowe) who team up to investigate the " +
                                      "disappearance of a teenage girl (Qualley).The Nice Guys premiered on May 11, 2016, in Hollywood, screened on May 15" +
                                      " at the 2016 Cannes Film Festival, and was released by Warner Bros. Pictures in the United States on May 20, 2016. It received" +
                                      " positive reviews from critics for its humor, mystery, and the performances of Crowe and Gosling. It grossed $62 million on" +
                                      " a $50 million budget.",
                        Price = 15,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/the nice guys.png"))),
                        VideoId = "https://www.youtube.com/embed/GQR5zsLHbYw?si=RF9vacXgHvSkO1_5"
                    },
                    new()
                    {
                        Title = "The Last Samurai",
                        Description = "The Last Samurai is a 2003 epic period action drama film directed and co-produced by Edward Zwick, who also co-wrote the" +
                                      " screenplay with John Logan and Marshall Herskovitz from a story devised by Logan. The film stars Ken Watanabe in the title" +
                                      " role, with Tom Cruise, who also co-produced, as a soldier-turned-samurai who befriends him, and Timothy Spall, Billy Connolly," +
                                      " Tony Goldwyn, Hiroyuki Sanada, Koyuki, and Masato Harada in supporting roles. Tom Cruise portrays Nathan Algren, an" +
                                      " American captain of the 7th Cavalry Regiment, whose personal and emotional conflicts bring him into contact with samurai " +
                                      "warriors in the wake of the Meiji Restoration in 19th century Japan. The film's plot was inspired by the 1877 Satsuma Rebellion," +
                                      " led by Saigō Takamori, and the Westernization of Japan by foreign powers.[a] The character of Algren is based on Eugène Collache" +
                                      " and Jules Brunet, both French Imperial Guard officers who fought alongside Enomoto Takeaki in the earlier Boshin War.",
                        Price = 19,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/the last samurai.png"))),
                        VideoId = "https://www.youtube.com/embed/YX265wacZcY?si=SquL49J6BDmGHZtf"
                    },
                    new()
                    {
                        Title = "The Dark Knight Trilogy",
                        Description = "Batman Begins is a 2005 superhero film directed by Christopher Nolan and written by Nolan and David S. Goyer. Based on the" +
                                      " DC Comics character Batman, it stars Christian Bale as Bruce Wayne / Batman, with Michael Caine, Liam Neeson, Katie Holmes," +
                                      " Gary Oldman, Cillian Murphy, Tom Wilkinson, Rutger Hauer, Ken Watanabe, and Morgan Freeman in supporting roles. The film " +
                                      "reboots the Batman film series, telling the origin story of Bruce Wayne from the death of his parents to his journey to" +
                                      " become Batman and his fight to stop Ra's al Ghul and the Scarecrow from plunging Gotham City into chaos." +
                                      "The Dark Knight is a 2008 superhero film directed by Christopher Nolan from a screenplay co-written with his brother Jonathan." +
                                      " Based on the DC Comics superhero Batman, it is the sequel to Batman Begins (2005) and the second installment in The Dark Knight" +
                                      " Trilogy. The plot follows the vigilante Batman, police lieutenant James Gordon, and district attorney Harvey Dent, who form an" +
                                      " alliance to dismantle organized crime in Gotham City. Their efforts are derailed by the Joker, an anarchistic mastermind who" +
                                      " seeks to test how far Batman will go to save the city from chaos." +
                                      "The Dark Knight Rises is a 2012 superhero film directed by Christopher Nolan, who co-wrote the screenplay with his brother" +
                                      " Jonathan Nolan, and the story with David S. Goyer. Based on the DC Comics character Batman, it is the final installment" +
                                      " in Nolan's The Dark Knight trilogy, and the sequel to The Dark Knight (2008). The film stars Christian Bale as Bruce Wayne / Batman," +
                                      " alongside Michael Caine, Gary Oldman, Anne Hathaway, Tom Hardy, Marion Cotillard, Joseph Gordon-Levitt, and Morgan Freeman." +
                                      " Eight years after the events of The Dark Knight, the terrorist Bane forces Bruce Wayne to resume his role as Batman and save" +
                                      " Gotham City from nuclear destruction. ",
                        Price = 50,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/dark knight.png"))),
                        VideoId = "https://www.youtube.com/embed/zkNDVV2RpQg?si=LUZcVPkg9gJXhAj1"
                    },
                    new()
                    {
                        Title = "Schindler's List",
                        Description = "Schindler's List is a 1993 American epic historical drama film directed and produced by Steven Spielberg and written by Steven Zaillian." +
                                      " It is based on the 1982 novel Schindler's Ark by Australian novelist Thomas Keneally. The film follows Oskar Schindler, a German" +
                                      " industrialist who saved more than a thousand mostly Polish–Jewish refugees from the Holocaust by employing them in his factories" +
                                      " during World War II. It stars Liam Neeson as Schindler, Ralph Fiennes as SS officer Amon Göth, and Ben Kingsley as Schindler's Jewish" +
                                      " accountant Itzhak Stern.",
                        Price = 12,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/schindlers list.png"))),
                        VideoId = "https://www.youtube.com/embed/mxphAlJID9U?si=bAOBlrXSf78Cog74"
                    },
                    new()
                    {
                        Title = "The Green Mile",
                        Description = "The Green Mile is a 1999 American fantasy drama film written and directed by Frank Darabont and based on Stephen King's 1996 novel of the" +
                                      " same name. It stars Tom Hanks as a death row prison guard during the Great Depression who witnesses supernatural events following the" +
                                      " arrival of an enigmatic convict (Michael Clarke Duncan) at his facility. David Morse, Bonnie Hunt, Sam Rockwell, and James Cromwell" +
                                      " appear in supporting roles.",
                        Price = 15,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/green mile.png"))),
                        VideoId = "https://www.youtube.com/embed/Bg7epsq0OIQ?si=RlHtEDHEjoYV__lr"
                    },
                    new()
                    {
                        Title = "The Prestige",
                        Description = "The Prestige is a 2006 psychological thriller film directed by Christopher Nolan, written by Nolan and his brother Jonathan and based on the 1995" +
                                      " novel by Christopher Priest. It stars Hugh Jackman as Robert Angier and Christian Bale as Alfred Borden, rival stage magicians in Victorian London" +
                                      " who feud over a perfect teleportation trick.",
                        Price = 14,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/the prestige.png"))),
                        VideoId = "https://www.youtube.com/embed/ELq7V8vkekI?si=ivG9IeF_rXzUzVFv"
                    },
                    new()
                    {
                        Title = "Gladiator",
                        Description = "Gladiator is a 2000 epic historical drama film directed by Ridley Scott and written by David Franzoni, John Logan, and William Nicholson." +
                                      " It was released by DreamWorks Pictures in North America, and Universal Pictures internationally through United International Pictures. It stars" +
                                      " Russell Crowe, Joaquin Phoenix, Connie Nielsen, Tomas Arana, Ralf Möller, Oliver Reed (in his final role), Djimon Hounsou, Derek Jacobi," +
                                      " John Shrapnel, Richard Harris, and Tommy Flanagan. Crowe portrays Roman general Maximus Decimus Meridius, who is betrayed when Commodus," +
                                      " the ambitious son of Emperor Marcus Aurelius, murders his father and seizes the throne. Reduced to slavery, Maximus becomes a gladiator and rises" +
                                      " through the ranks of the arena to avenge the murders of his family and his emperor.",
                        Price = 15,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/gladiator.png"))),
                        VideoId = "https://www.youtube.com/embed/P5ieIbInFpg?si=ZNkkRafdSnw8bFvV"
                    },
                    new()
                    {
                        Title = "Good Will Hunting",
                        Description = "Will Hunting (Matt Damon) has a genius-level IQ but chooses to work as a janitor at MIT. When he solves a difficult graduate-level math problem," +
                                      " his talents are discovered by Professor Gerald Lambeau (Stellan Skarsgard), who decides to help the misguided youth reach his potential. When Will" +
                                      " is arrested for attacking a police officer, Professor Lambeau makes a deal to get leniency for him if he will get treatment from therapist Sean Maguire" +
                                      " (Robin Williams).",
                        Price = 12,
                        Image = GenerateImageBytes(Image.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/good will hunting.png"))),
                        VideoId = "https://www.youtube.com/embed/ReIJ1lbL-Q8?si=bEzpEguycxLUgdtv"
                    }
                };

                context.Movies.AddRange(movies);
                await context.SaveChangesAsync();
            }
        }

        private static byte[] GenerateImageBytes(Image image)
        {
            using var ms = new MemoryStream();
            image.Save(ms, new PngEncoder());
            return ms.ToArray();
        }
    }
}
