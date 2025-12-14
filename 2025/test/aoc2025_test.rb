# frozen_string_literal: true

require "test_helper"

# Test for AoC2025
class TestAoc2025 < Minitest::Test
  def test_day1
    assert Aoc2025.solve(1, 1, true) === 3
    assert Aoc2025.solve(1, 2, true) === 6
  end

  def test_day2
    assert Aoc2025.solve(2, 1, true) === 1227775554
    assert Aoc2025.solve(2, 2, true) === 4174379265
  end

  def test_day3
    assert_equal 357, Aoc2025.solve(3, 1, true)
    assert_equal 3121910778619, Aoc2025.solve(3, 2, true)
  end

  def test_day4
    assert_equal 13, Aoc2025.solve(4, 1, true)
    assert_equal 43, Aoc2025.solve(4, 2, true)
  end
end
