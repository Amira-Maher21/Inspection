using Inspection.Application.Contracts.Dto.Posting; // Add this using if not present
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Posting;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.JournalEntrys;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Event;
using Inspection.Domain.Event.Posting;
using Microsoft.AspNetCore.Mvc;

namespace Inspection.API.Controllers.Controllers.Posting
{
    [Route("api/Posting/[action]")]
    [ApiController]
    public class PostingController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        private readonly IPostingEngine _postingEngine;


        public PostingController(IAccountsServicesManger servicesManger, IPostingEngine postingEngine)
        {
            _servicesManger = servicesManger;
            //_journalQueryRepo = journalQueryRepo;
            _postingEngine = postingEngine ?? throw new ArgumentNullException(nameof(postingEngine));
        }


        [HttpPost("PostDocument")]
        public async Task<IActionResult> PostDocument(PostDocumentRequest request)
        {
            try
            {
                var document = await _postingEngine.GetPostingDocument(request.DocumentCode, request.Id);

                if (document.Posting == PostingEnum.Posted)
                    return BadRequest(new { Error = $"Document {request.DocumentCode} with ID {request.Id} is already posted" });

                await _postingEngine.PostAsync((dynamic)document);

                return Ok(new
                {
                    Message = "Document Posted Successfully",
                    DocumentCode = request.DocumentCode,
                    Id = request.Id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("PostAllUnposted")]
        public async Task<IActionResult> PostAllUnpostedDocuments()
        {
            try
            {
                var result = await _postingEngine.PostAllUnpostedDocumentsAsync();

                return Ok(new
                {
                    Message = "Batch posting completed",
                    Summary = new
                    {
                        result.SuccessCount,
                        result.FailureCount,
                        result.TotalDuration,
                        StartTime = result.StartTime,
                        EndTime = result.EndTime
                    },
                    Details = result.ProcessedDocuments
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("PostUnpostedByType/{documentCode}")]
        public async Task<IActionResult> PostUnpostedByType(string documentCode)
        {
            try
            {
                var result = await _postingEngine.PostUnpostedDocumentsByTypeAsync(documentCode);

                return Ok(new
                {
                    Message = $"Batch posting completed for {documentCode}",
                    Summary = new
                    {
                        result.SuccessCount,
                        result.FailureCount,
                        result.TotalDuration,
                        StartTime = result.StartTime,
                        EndTime = result.EndTime
                    },
                    Details = result.ProcessedDocuments
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // reverse ledger
        [HttpPost("ReverseLedger/{ledgerId}")]
        public async Task<IActionResult> ReverseLedger(long ledgerId)
        {
            try
            {
                var reversedId = await _postingEngine.ReverseLedgerAsync(ledgerId);

                return Ok(new
                {
                    Message = $"Ledger {ledgerId} reversed successfully",
                    ReversedLedgerId = reversedId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}