data class TrieNode(
    var isWord: Boolean = false,
    var word: String? = null,
    val children: HashMap<Char, TrieNode> = hashMapOf()
)