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
    case File.read('/src/elixir/advent_of_code/day1/input_real.txt') do
      {:ok, contents} ->
        elves_calories =
          contents
          |> String.trim()
          |> String.split("\n\n", trim: true)
          results = Enum.map(elves_calories, &Elf.calc/1)
          IO.inspect Enum.max(results)
        {:error, reason} ->
            # Handle the error here
            IO.puts "Error reading file: #{reason}"
    end
  end
end

Elves.import
