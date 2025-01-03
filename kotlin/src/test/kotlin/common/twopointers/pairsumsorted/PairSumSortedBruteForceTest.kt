package common.twopointers.pairsumsorted

import org.junit.jupiter.api.Assertions.assertAll
import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.function.Executable

class PairSumSortedBruteForceTest {

    private val question = PairSumSortedBruteForce()

    @Test
    fun `Expected pair is found and valid`() {
        assertAll(
            Executable {
                assertEquals(question.solution(intArrayOf(-5, -2, 3, 4, 6), 7), listOf(2, 3))
            },
            Executable {
                assertEquals(question.solution(intArrayOf(1, 1, 1), 2), listOf(0, 1))
            },
            Executable {
                assertEquals(question.solution(intArrayOf(2, 3), 5), listOf(0, 1))
            },
        )
    }

    @Test
    fun `Expected pair is empty`() {
        assertAll(
            Executable {
                assertEquals(question.solution(intArrayOf(), 0), emptyList<Int>())
            },
            Executable {
                assertEquals(question.solution(intArrayOf(1), 1), emptyList<Int>())
            },
            Executable {
                assertEquals(question.solution(intArrayOf(2, 4), 5), emptyList<Int>())
            }
        )
    }

}