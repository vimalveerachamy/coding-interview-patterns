package common.twopointers.nextlexicographicalsequence

import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class NextLexicographicalSequenceTest {

    private val question = NextLexicographicalSequence()

    @Test
    fun `Verify solution`() {
        assertEquals("a", question.solution("a"))
        assertEquals("aaaa", question.solution("aaaa"))
        assertEquals("ynsdeit", question.solution("ynitsed"))
        assertEquals("nuash", question.solution("nuahs"))
        assertEquals("abdc", question.solution("abcd"))
        assertEquals("abcd", question.solution("dcba"))
    }
}