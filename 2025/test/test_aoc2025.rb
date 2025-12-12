# frozen_string_literal: true

require 'test_helper'

# Test for AoC2025
class TestAoc2025 < Minitest::Test
  def test_day3
    assert Aoc2025.solve(3, 1, true).zero?
  end
end
