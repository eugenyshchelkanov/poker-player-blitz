namespace Nancy.Simple
{
    public class Card
    {
        CardType Type { get; set; }
        CardColor Color { get; set; }
    }

    public enum CardType
    {
        Card2,
        Card3,
        Card4,
        Card5,
        Card6,
        Card7,
        Card8,
        Card9,
        Card10,
        /// <summary>
        /// �����
        /// </summary>
        Jack,
        /// <summary>
        /// ��������
        /// </summary>
        Queen,
        /// <summary>
        /// ������
        /// </summary>
        King,
        /// <summary>
        /// ���
        /// </summary>
        Ace
    }
}