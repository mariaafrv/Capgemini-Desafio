using System;

public class ADCalculator
{
    #region Views
    private int _newViewers;
    private int _totalViewers;
    private int _totalClicks;
    private int _totalShares;
    #endregion

    #region Accessors
    public int TotalViewers{ get {return _totalViewers;} }
    public int TotalClicks{ get {return _totalClicks;} }
    public int TotalShares{ get {return _totalShares;} }
    #endregion

    private int _maxSequence = 4;
    private int _viewByReal = 30;
    
    #region Calculator functions
    public void Calculate(float investedAmount)
    {   
        // 30 pessoas que visualizam o anúncio original (não compartilhado) a cada R$ 1,00 investido.
        int originalViewers =  (int)(investedAmount * _viewByReal);
        _totalViewers = originalViewers;

        // o mesmo anúncio é compartilhado no máximo 4 vezes em sequência
        // (1ª pessoa -> compartilha -> 2ª pessoa -> compartilha - > 3ª pessoa -> compartilha -> 4ª pessoa)
        while (_maxSequence != 0)
        {
            if (_maxSequence == 4) // AD Postado
            {
                Sequence(originalViewers);
            }
            else
            {
                Sequence(_newViewers); // Segundo, terceiro e quarto

            }
        }
    }

    private void Sequence(int viewers)
    {
            // A cada 100 pessoas que visualizam o anúncio 12 clicam nele.
            float percent12 = 12f / 100f;
            int clicks = (int)(viewers * percent12);
            _totalClicks += clicks;

             // A cada 20 pessoas que clicam no anúncio 3 compartilham nas redes sociais.
            float percent15 = 15f / 100f;
            int shares = (int)(clicks  * percent15);
            _totalShares += shares;
            _maxSequence --;

             // Cada compartilhamento nas redes sociais gera 40 novas visualizações.
            int valueByShare = 40;
            _newViewers = (int)(shares * valueByShare);
            _totalViewers += _newViewers;
    }
#endregion
}