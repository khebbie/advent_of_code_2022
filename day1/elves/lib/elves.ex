
defmodule Elf do
  def calc(calories) do
      calories
      |> String.split("\n")
      |> Enum.map(&String.to_integer/1)
      |> Enum.sum()
    end
  end

defmodule Elves do
  def import do
    {:ok, contents} = File.read('/src/elixir/advent_of_code/day1/input_real.txt')

    elves_calories =
      contents
      |> String.trim()
      |> String.split("\n\n", trim: true)
    results = Enum.map(elves_calories, &Elf.calc/1)
    IO.inspect results


  end
end

Elves.import
