namespace yaml_story
{
    public class DialogBatch
    {

        public static readonly int VISIBILITY_UNSET = -1;
        public static readonly int VISIBILITY_VISIBLE = 1;
        public static readonly int VISIBILITY_GONE = 0;

        public string? backgroundImg = null;

        public string? text = null;

        public string? sound = "";

        public bool autoplay = false;

        public int dialogVisibility = VISIBILITY_UNSET;

        public List<Option>? options = null;

        public class Option
        {
            public string name = "";

            public List<DialogBatch> branchSeq = [];

            public override string ToString()
            {
                var listStr = "";
                if (branchSeq.Count > 0)
                {
                    foreach(var a in branchSeq)
                    {
                        listStr += a.ToString();
                    }
                }
                return $"name: {name}, branchSeq: {listStr}\n";
            }
        }

        public override string ToString()
        {
            var str = $"Batch: \nbackgroundImg: {backgroundImg}, text: {text}\nsound: {sound}, autoplay: {autoplay}\n";
            if (options != null && options.Count> 0)
            { 
                foreach (var a in options)
                {
                    str += a.ToString() ; 
                }

            }
            return str+"\n\n\n" ;
        }
    }
}
