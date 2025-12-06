# frozen_string_literal: true

require_relative 'day1'
require_relative 'day2'

# Aoc 2025 solutions
module Aoc2025
  @solutions = [[Day1.method(:part1), Day1.method(:part2)],
                [Day2.method(:part1), Day2.method(:part2)]]

  def self.solve(day, part, test)
    file_path = "inputs/day#{day}#{test ? 'small' : ''}.txt"

    @solutions[day - 1][part - 1].call(file_path)
  end
end
