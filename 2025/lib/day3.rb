# frozen_string_literal: true

# Day 3 solutions
module Day3
  def self.part1(path)
    File.foreach(path).sum do |line|
      get_max_joltage(line, 2)
    end
  end

  def self.part2(path)
    File.foreach(path).sum do |line|
      get_max_joltage(line, 12)
    end
  end

  def self.get_max_joltage(line, length)
    joltages = line.chars.map(&:to_i)
    digits = []
    index = 0

    while digits.size < length
      value, next_index = joltages[index...(-length + digits.size)].each_with_index.max_by { |value, index| value }

      index += next_index + 1

      digits << value
    end

    digits.join.to_i
  end
end
