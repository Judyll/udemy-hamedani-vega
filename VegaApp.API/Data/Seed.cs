using System.Collections.Generic;
using System.Linq;
using VegaApp.API.Models;

namespace VegaApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context) {
            _context = context;
        }

        public void SeedData() {

            if (!_context.Makes.Any()) {
                _context.Makes.Add(new Make {
                    Name = "Ford",
                    Models = new List<Model> {
                        new Model {
                            Name = "WildTrak"
                        },
                        new Model {
                            Name = "EcoSports"
                        },
                        new Model {
                            Name = "Everest"
                        }
                    }
                });

                _context.Makes.Add(new Make {
                    Name = "Toyota",
                    Models = new List<Model> {
                        new Model {
                            Name = "HiLux"
                        },
                        new Model {
                            Name = "Fortuner"
                        }
                    }
                });

                _context.SaveChanges();
            }

            if (!_context.Features.Any()) {
                _context.Features.Add(new Feature {
                    Name = "ABS"
                });
                _context.Features.Add(new Feature {
                    Name = "Power Window"
                });
                _context.Features.Add(new Feature {
                    Name = "GPS"
                });                

                _context.SaveChanges();
            }
        }
    }
}