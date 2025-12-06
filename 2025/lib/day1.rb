# frozen_string_literal: true

# Day 1 solutions
module Day1
  def self.part1(path)
    position = 50
    zero_count = 0

    File.foreach(path) do |line|
      position += get_rotation(line)
      position %= 100
      zero_count += 1 if position.zero?
    end

    zero_count
  end

  def self.part2(path)
    position = 50
    zero_count = 0

    File.foreach(path) do |line|
      next_position = position + get_rotation(line)
      zero_count += 1 if passed_zero?(position, next_position)
      zero_count += next_position.abs / 100
      position = next_position % 100
    end

    zero_count
  end

  def self.get_rotation(line)
    direction, distance = line.scan(/[LR]+|\d+/)

    direction == 'L' ? distance.to_i : -distance.to_i
  end

  def self.passed_zero?(position, next_position)
    next_position.zero? ||
      (position.negative? && next_position.positive?) ||
      (position.positive? && next_position.negative?)
  end
end
