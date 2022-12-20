defmodule Elf do
  def calc(calories) do
    calories
    |> String.split("\n")
    |> Enum.map(&String.to_integer/1)
    |> Enum.sum()
  end
end

defmodule Elves do
  def start do
    case File.read('/src/elixir/advent_of_code/day1/input_real.txt') do
      {:ok, contents} ->
        calculate_all_elves(contents)

      {:error, reason} ->
        # Handle the error here
        IO.puts("Error reading file: #{reason}")
    end
  end

  def calculate_all_elves(contents) do
    elves_calories =
      contents
      |> String.trim()
      |> String.split("\n\n", trim: true)

    results = Enum.map(elves_calories, &Elf.calc/1)
    IO.inspect(Enum.max(results))
  end
end

Elves.start()
