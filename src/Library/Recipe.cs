//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }
        // The receipt is responsible for getting the total cost of the final product, I used expert responsability assignment.
        public double GetProductionCost(){
            double total = 0;
            foreach (Step step in this.steps){
                total = total + step.TotalCost();
            }
            return total;
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time} y con un coste de: {step.TotalCost().ToString()}");
            }
            Console.WriteLine("Con un coste toal de: "+GetProductionCost().ToString());
        }
    }
}