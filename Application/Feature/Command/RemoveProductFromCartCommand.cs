namespace Application.Feture.Command
{
    public class RemoveProductFromCartCommand
    {
        public int ProductId{ get; set; }
        public int CartId{ get; set; }
    }
}