#[cfg(test)]
mod tests {
    use crate::days::day2::{resolve_part_1, resolve_part_2};


    #[test]
    fn should_compute_part_1() {
        let result = resolve_part_1("src/days/day2/input_small.txt");
        assert_eq!(result, 15);
    }

    #[test]
    fn should_compute_part_2() {
        let result = resolve_part_2("src/days/day2/input_small.txt");
        assert_eq!(result, 12);
    }
}