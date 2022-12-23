#[cfg(test)]
mod tests {
    use std::path::Path;

    use crate::{days::day3, utils::read_test_input_file};


    #[test]
    fn should_compute_part_1() {
        let string = &read_test_input_file(3);
        let result = day3::resolve_part_1(string);
        assert_eq!(result, "157");
    }

    #[test]
    fn should_compute_part_2() {
        let string = &read_test_input_file(3);
        let result = day3::resolve_part_2(string);
        assert_eq!(result, "70");
    }
}