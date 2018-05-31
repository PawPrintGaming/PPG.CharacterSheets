using GraphQL.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace PPG.CharacterSheets.GraphQL
{
    [Route("schema")]
    public class SchemaController : Controller
    {
        private readonly CharactersSchema _schema;

        public SchemaController(CharactersSchema schema)
        {
            _schema = schema;
        }
        public IActionResult GetSchema()
        {
            var printer = new SchemaPrinter(_schema);
            return Ok(printer.Print());
        }
    }
}