defmodule ElvesTest do
  use ExUnit.Case
  doctest Elves

  test "greets the world" do
    assert Elves.hello() == :world
  end
end
