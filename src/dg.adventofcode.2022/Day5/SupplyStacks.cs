using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace dg.adventofcode._2022.Day5;

public static class SupplyStacks
{
    public static string GetTopCrates(List<string> input, bool activate9001 = false)
    {
        var (stacks, instructions) = ParseHeaderAndInstructions(input);

        foreach (var instruction in instructions)
        {
            if (activate9001)
            {
                var holdingStack = new Stack<string>();
                for (var i = instruction.NumToMove; i > 0; i--)
                {
                    holdingStack.Push(stacks[instruction.IndexToMoveFrom - 1].Pop());
                }
                for (var i = instruction.NumToMove; i > 0; i--)
                {
                    stacks[instruction.IndexToMoveTo - 1].Push(holdingStack.Pop());
                }
            }
            else
            {
                for (var i = instruction.NumToMove; i > 0; i--)
                {
                    var value  = stacks[instruction.IndexToMoveFrom - 1].Pop();
                    stacks[instruction.IndexToMoveTo - 1].Push(value);
                }
            }
        }

        var finalValue = stacks.Aggregate("", (current, stack) => current + stack.Pop());

        return finalValue;
    }

    private static (List<Stack<string>> stacks, List<Instruction> instructions) ParseHeaderAndInstructions(
        List<string> input)
    {
        var header = true;
        var stacks = new List<Stack<string>>();
        var instructions = new List<Instruction>();

        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                header = false;
                continue;
            }

            if (header)
            {
                AddStacksAndValues(line, ref stacks);
            }
            else
            {
                instructions.Add(ParseInstruction(line));
            }
        }

        return (stacks, instructions);
    }

    private static Instruction ParseInstruction(string line)
    {
        var regexMatches = Regex.Matches(line, "(\\d)+");
        var numbers = regexMatches.Select(v => Convert.ToInt32(v.ToString())).ToList();
        
        return new Instruction
        {
            NumToMove = numbers[0],
            IndexToMoveFrom = numbers[1],
            IndexToMoveTo = numbers[2]
        };
    }

    private static void AddStacksAndValues(string line, ref List<Stack<string>> stacks)
    {
        if (line.Any(char.IsDigit))
        {
            stacks = ReverseStacks(stacks);
            return;
        }

        for (var i = 0; i < line.Length; i++)
        {
            if (IsAStackValue(line, i))
            {
                var belongingStackIndex = Convert.ToInt32(Math.Ceiling((double)i / 4));
                while (belongingStackIndex > stacks.Count)
                    stacks.Add(new Stack<string>());
                stacks[belongingStackIndex - 1].Push(line[i].ToString());
            }
        }
    }

    private static List<Stack<string>> ReverseStacks(List<Stack<string>> stacks)
    {
        var newStackList = new List<Stack<string>>();
        foreach (var stack in stacks)
        {
            var reversedStack = ReverseSingleStack(stack);
            newStackList.Add(reversedStack);
        }

        return newStackList;
    }

    private static Stack<string> ReverseSingleStack(Stack<string> stack)
    {
        var holdingStack = new Stack<string>();
        while (stack.Count != 0)
        {
            holdingStack.Push(stack.Pop());
        }

        return holdingStack;
    }

    private static bool IsAStackValue(string line, int i)
    {
        return line[i] != ' ' && line[i] != '[' && line[i] != ']';
    }

    private class Instruction
    {
        public int NumToMove { get; set; }
        public int IndexToMoveFrom { get; set; }
        public int IndexToMoveTo { get; set; }
    }
}