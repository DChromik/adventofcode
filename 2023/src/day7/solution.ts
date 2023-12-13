import { ReadStream } from "fs";
import { reduceLines } from "../util";

interface Hand {
	rank: number;
	bid: number;
}

enum HandStrength {
	HighCard = 1,
	Pair = 2,
	DoublePair = 3,
	Three = 4,
	FullHouse = 5,
	Four = 6,
	Five = 7,
}

export async function resolvePart1(stream: ReadStream): Promise<number> {
	const hands = await reduceLines(stream, (hands, line) => {
		return [...hands, parseLine(line)];
	}, [] as Hand[]);
	return hands
		.sort((a, b) => a.rank - b.rank)
		.reduce((winnings, hand, index) => {
			return winnings + (hand.bid * (index + 1));
		}, 0);
}

export async function resolvePart2(stream: ReadStream): Promise<number> {
	const result = await reduceLines(stream, (acc) => {
		return acc;
	}, 0);
	return result;
}

function parseLine(line: string): Hand {
	const [cards, bid] = line.split(' ');

	return {
		rank: getCardsRank(cards.split('')),
		bid: parseInt(bid, 10),
	}
}

function getCardsRank(cards: string[]): number {
	return cards.reduce((rank, card) => {
		const cardValue = getCardValue(card);
		return rank * 16 + cardValue;
	}, getHandStrength(cards));
}

function getHandStrength(cards: string[]): number {
	const cardCount = cards.reduce((counts, card) => {
		const count = counts.get(card) || 0;
		counts.set(card, count + 1);
		return counts;
	}, new Map());
	const combination = Array.from(cardCount.values())
		.filter((count) => count > 1)
		.sort()
		.join('');
	switch (parseInt(combination, 10)) {
		case 2: return HandStrength.Pair;
		case 22: return HandStrength.DoublePair;
		case 3: return HandStrength.Three;
		case 32: return HandStrength.FullHouse;
		case 4: return HandStrength.Four;
		case 5: return HandStrength.Five;
		default: return HandStrength.HighCard;
	}
}

function getCardValue(card: string) {
	switch (card) {
		case 'A': return 14;
		case 'K': return 13;
		case 'Q': return 12;
		case 'J': return 11;
		case 'T': return 10;
		default: return parseInt(card, 10);
	}
}
