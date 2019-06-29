namespace Bowling
{
    public class JogoDeBoliche : Game
    {
        public void Jogar(int pinos) => base.Play(pinos);
        public int ObterPontuacao() => base.GetPoints();
    }
}