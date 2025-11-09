using System;
using System.Collections.Generic;
using System.Linq;

        List<int> pokemonDistance = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        int sum = 0;

        while (pokemonDistance.Count > 0)
        {
            int index = int.Parse(Console.ReadLine());
            int removedElement;

            if (index < 0)
            {
                removedElement = pokemonDistance[0];
                pokemonDistance[0] = pokemonDistance[pokemonDistance.Count - 1];
            }
            else if (index >= pokemonDistance.Count)
            {
                removedElement = pokemonDistance[pokemonDistance.Count - 1];
                pokemonDistance[pokemonDistance.Count - 1] = pokemonDistance[0];
            }
            else
            {
                removedElement = pokemonDistance[index];
                pokemonDistance.RemoveAt(index);
            }

            sum += removedElement;
            for (int i = 0; i < pokemonDistance.Count; i++)
            {
                if (pokemonDistance[i] <= removedElement)
                {
                    pokemonDistance[i] += removedElement;
                }
                else
                {
                    pokemonDistance[i] -= removedElement;
                }
            }
        }
        Console.WriteLine(sum);
