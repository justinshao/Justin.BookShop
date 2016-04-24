using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.IService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels = Justin.BookShop.Controllers.Models;
using DomainModels = Justin.BookShop.Entities;

namespace Justin.BookShop.Controllers.Admin
{
    public class ReceiptController : AdminController
    {
        #region 单据输入相关
        public ActionResult List(ReceiptType type)
        {
            object receiptList = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    {
                        var list = LoginUser.SubmittedInStockReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.OutStock:
                    {
                        var list = LoginUser.SubmittedOutStockReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.Stocktake:
                    {
                        var list = LoginUser.SubmittedStocktakeReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.StockDamaged:
                    {
                        var list = LoginUser.SubmittedStockDamagedReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.PriceAdjust:
                    {
                        var list = LoginUser.SubmittedPriceAdjustReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
            }

            return Json(receiptList);
        }

        public ActionResult SubmitIndex(ReceiptType type)
        {
            string viewName = null;
            object receiptList = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    {
                        var list = LoginUser.SubmittedInStockReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "InStock";
                        break;
                    }
                case ReceiptType.OutStock:
                    {
                        var list = LoginUser.SubmittedOutStockReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "OutStock";
                        break;
                    }
                case ReceiptType.Stocktake:
                    {
                        var list = LoginUser.SubmittedStocktakeReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "Stocktake";
                        break;
                    }
                case ReceiptType.StockDamaged:
                    {
                        var list = LoginUser.SubmittedStockDamagedReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "StockDamaged";
                        break;
                    }
                case ReceiptType.PriceAdjust:
                    {
                        var list = LoginUser.SubmittedPriceAdjustReceipts.Where(r => !r.IsAudited).OrderBy(r => r.NO).Select(r => r).ToList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "PriceAdjust";
                        break;
                    }
                default:
                    return HttpNotFound("请求的页面不存在");
            }

            ViewBag.UseLayout = true;
            ViewBag.Layout = "~/Views/Shared/SubmitReceipt.cshtml";
            ViewBag.ReceiptList = Util.SerializeToJson(receiptList);
            ViewBag.Type = (int)type;
            return View(viewName, null);
        }

        public ActionResult SubmittedReceipt(ReceiptType type, Guid id)
        {
            string viewName = null;
            object receipt = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    receipt = LoginUser.SubmittedInStockReceipts.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
                    viewName = "InStock";
                    break;
                case ReceiptType.OutStock:
                    receipt = LoginUser.SubmittedOutStockReceipts.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
                    viewName = "OutStock";
                    break;
                case ReceiptType.Stocktake:
                    receipt = LoginUser.SubmittedStocktakeReceipts.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
                    viewName = "Stocktake";
                    break;
                case ReceiptType.StockDamaged:
                    receipt = LoginUser.SubmittedStockDamagedReceipts.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
                    viewName = "StockDamaged";
                    break;
                case ReceiptType.PriceAdjust:
                    receipt = LoginUser.SubmittedPriceAdjustReceipts.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
                    viewName = "PriceAdjust";
                    break;
                default:
                    return Content("");
            }

            if (receipt == null)
                return Content("");
            ViewBag.UseLayout = false;
            return View(viewName, receipt);
        }

        public ActionResult TemporaryReceipts(ReceiptType type)
        {
            return null;
        }

        public ActionResult ReceiptEdit(ReceiptType type, Guid? id)
        {
            var viewName = "";
            object receipt = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    {
                        var r = ResolveService<IInStockReceiptService>().GetTemporaryReceipt(id.GetValueOrDefault());
                        if (r != null)
                        {
                            var _r = r.CopyToViewModel();
                            _r.Details.Add(new ViewModels.InStockReceiptDetail());
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "edit";
                        }
                        else
                        {
                            var _r = new InStockReceipt
                            {
                                NO = "",
                                PressName = "",
                                PressNO = "",
                                Remark = "",
                                Details = new List<ViewModels.InStockReceiptDetail>() { new ViewModels.InStockReceiptDetail() }
                            };
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "add";
                        }
                        viewName = "InStockEdit";
                        break;
                    }
                case ReceiptType.OutStock:
                    {
                        var r = ResolveService<IOutStockReceiptService>().GetTemporaryReceipt(id.GetValueOrDefault());
                        if (r != null)
                        {
                            var _r = r.CopyToViewModel();
                            _r.Details.Add(new ViewModels.OutStockReceiptDetail());
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "edit";
                        }
                        else
                        {
                            var _r = new OutStockReceipt
                            {
                                NO = "",
                                OrderNO = "",
                                Remark = "",
                                Details = new List<ViewModels.OutStockReceiptDetail>() { new ViewModels.OutStockReceiptDetail() }
                            };
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "add";
                        }
                        viewName = "OutStockEdit";
                        break;
                    }
                case ReceiptType.Stocktake:
                    {
                        var r = ResolveService<IStocktakeReceiptService>().GetTemporaryReceipt(id.GetValueOrDefault());
                        if (r != null)
                        {
                            var _r = r.CopyToViewModel();
                            _r.Details.Add(new ViewModels.StocktakeReceiptDetail());
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "edit";
                        }
                        else
                        {
                            var _r = new StocktakeReceipt
                            {
                                NO = "",
                                Remark = "",
                                Details = new List<ViewModels.StocktakeReceiptDetail>() { new ViewModels.StocktakeReceiptDetail() }
                            };
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "add";
                        }
                        viewName = "StocktakeEdit";
                        break;
                    }
                case ReceiptType.StockDamaged:
                    {
                        var r = ResolveService<IStockDamagedReceiptService>().GetTemporaryReceipt(id.GetValueOrDefault());
                        if (r != null)
                        {
                            var _r = r.CopyToViewModel();
                            _r.Details.Add(new ViewModels.StockDamagedReceiptDetail());
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "edit";
                        }
                        else
                        {
                            var _r = new StockDamagedReceipt
                            {
                                NO = "",
                                Remark = "",
                                Details = new List<ViewModels.StockDamagedReceiptDetail>() { new ViewModels.StockDamagedReceiptDetail() }
                            };
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "add";
                        }
                        viewName = "StockDamagedEdit";
                        break;
                    }
                case ReceiptType.PriceAdjust:
                    {
                        var r = ResolveService<IPriceAdjustReceiptService>().GetTemporaryReceipt(id.GetValueOrDefault());
                        if (r != null)
                        {
                            var _r = r.CopyToViewModel();
                            _r.Details.Add(new ViewModels.PriceAdjustReceiptDetail());
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "edit";
                        }
                        else
                        {
                            var _r = new PriceAdjustReceipt
                            {
                                NO = "",
                                Remark = "",
                                Details = new List<ViewModels.PriceAdjustReceiptDetail>() { new ViewModels.PriceAdjustReceiptDetail() }
                            };
                            ViewBag.Detail = Util.SerializeToJson(_r.Details);
                            receipt = _r;
                            ViewBag.EditMode = "add";
                        }
                        viewName = "PriceAdjustEdit";
                        break;
                    }
                default:
                    break;
            }

            return View(viewName, receipt);
        }

        public ActionResult SaveInStockReceipt(ViewModels.InStockReceipt receipt, SaveMode mode)
        {
            DomainModels.InStockReceipt r = receipt.CopyToDomainModel();
            r.SubmittedBy = LoginUser;
            if (mode == SaveMode.Add)
            {
                ResolveService<IInStockReceiptService>().SubmitTemporaryReceipt(r);
            }
            else if (mode == SaveMode.Update)
            {
                ResolveService<IInStockReceiptService>().UpdateTemporaryReceipt(r);
            }
            else
            {
                return Json(new JsonResultData
                {
                    Success = false,
                    ErrorMessage = "未知的请求类型"
                });
            }

            return Json(new JsonResultData
            {
                Success = true
            });
        }

        public ActionResult SaveOutStockReceipt(ViewModels.OutStockReceipt receipt, SaveMode mode)
        {
            DomainModels.OutStockReceipt r = receipt.CopyToDomainModel();
            r.SubmittedBy = LoginUser;
            if (mode == SaveMode.Add)
            {
                ResolveService<IOutStockReceiptService>().SubmitTemporaryReceipt(r);
            }
            else if (mode == SaveMode.Update)
            {
                ResolveService<IOutStockReceiptService>().UpdateTemporaryReceipt(r);
            }
            else
            {
                return Json(new JsonResultData
                {
                    Success = false,
                    ErrorMessage = "未知的请求类型"
                });
            }

            return Json(new JsonResultData
            {
                Success = true
            });
        }

        public ActionResult SaveStocktakeReceipt(ViewModels.StocktakeReceipt receipt, SaveMode mode)
        {
            DomainModels.StocktakeReceipt r = receipt.CopyToDomainModel();
            r.SubmittedBy = LoginUser;
            if (mode == SaveMode.Add)
            {
                ResolveService<IStocktakeReceiptService>().SubmitTemporaryReceipt(r);
            }
            else if (mode == SaveMode.Update)
            {
                ResolveService<IStocktakeReceiptService>().UpdateTemporaryReceipt(r);
            }
            else
            {
                return Json(new JsonResultData
                {
                    Success = false,
                    ErrorMessage = "未知的请求类型"
                });
            }

            return Json(new JsonResultData
            {
                Success = true
            });
        }

        public ActionResult SaveStockDamagedReceipt(ViewModels.StockDamagedReceipt receipt, SaveMode mode)
        {
            DomainModels.StockDamagedReceipt r = receipt.CopyToDomainModel();
            r.SubmittedBy = LoginUser;
            if (mode == SaveMode.Add)
            {
                ResolveService<IStockDamagedReceiptService>().SubmitTemporaryReceipt(r);
            }
            else if (mode == SaveMode.Update)
            {
                ResolveService<IStockDamagedReceiptService>().UpdateTemporaryReceipt(r);
            }
            else
            {
                return Json(new JsonResultData
                {
                    Success = false,
                    ErrorMessage = "未知的请求类型"
                });
            }

            return Json(new JsonResultData
            {
                Success = true
            });
        }

        public ActionResult SavePriceAdjustReceipt(ViewModels.PriceAdjustReceipt receipt, SaveMode mode)
        {
            DomainModels.PriceAdjustReceipt r = receipt.CopyToDomainModel();
            r.SubmittedBy = LoginUser;
            if (mode == SaveMode.Add)
            {
                ResolveService<IPriceAdjustReceiptService>().SubmitTemporaryReceipt(r);
            }
            else if (mode == SaveMode.Update)
            {
                ResolveService<IPriceAdjustReceiptService>().UpdateTemporaryReceipt(r);
            }
            else
            {
                return Json(new JsonResultData
                {
                    Success = false,
                    ErrorMessage = "未知的请求类型"
                });
            }

            return Json(new JsonResultData
            {
                Success = true
            });
        }

        [HttpPost]
        public ActionResult DeleteReceipt(ReceiptType type, Guid? id)
        {
            switch (type)
            {
                case ReceiptType.InStock:
                    ResolveService<IInStockReceiptService>().RemoveTemporaryReceipt(id.GetValueOrDefault());
                    break;
                case ReceiptType.OutStock:
                    ResolveService<IOutStockReceiptService>().RemoveTemporaryReceipt(id.GetValueOrDefault());
                    break;
                case ReceiptType.Stocktake:
                    ResolveService<IStocktakeReceiptService>().RemoveTemporaryReceipt(id.GetValueOrDefault());
                    break;
                case ReceiptType.StockDamaged:
                    ResolveService<IStockDamagedReceiptService>().RemoveTemporaryReceipt(id.GetValueOrDefault());
                    break;
                case ReceiptType.PriceAdjust:
                    ResolveService<IPriceAdjustReceiptService>().RemoveTemporaryReceipt(id.GetValueOrDefault());
                    break;
                default:
                    break;
            }

            return Json(new JsonResultData
            {
                Success = true
            });
        } 
        #endregion

        #region 单据审核相关
        public ActionResult AuditIndex(ReceiptType type)
        {
            string viewName = null;
            object receiptList = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    {
                        var list = ResolveService<IInStockReceiptService>().GetTemporaryReceiptList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "InStock";
                        break;
                    }
                case ReceiptType.OutStock:
                    {
                        var list = ResolveService<IOutStockReceiptService>().GetTemporaryReceiptList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "OutStock";
                        break;
                    }
                case ReceiptType.Stocktake:
                    {
                        var list = ResolveService<IStocktakeReceiptService>().GetTemporaryReceiptList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "Stocktake";
                        break;
                    }
                case ReceiptType.StockDamaged:
                    {
                        var list = ResolveService<IStockDamagedReceiptService>().GetTemporaryReceiptList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "StockDamaged";
                        break;
                    }
                case ReceiptType.PriceAdjust:
                    {
                        var list = ResolveService<IPriceAdjustReceiptService>().GetTemporaryReceiptList();
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "PriceAdjust";
                        break;
                    }
                default:
                    return HttpNotFound("请求的页面不存在");
            }

            ViewBag.UseLayout = true;
            ViewBag.Layout = "~/Views/Shared/AuditReceipt.cshtml";
            ViewBag.ReceiptList = Util.SerializeToJson(receiptList);
            ViewBag.Type = (int)type;
            return View(viewName, null);
        }

        [HttpPost]
        public ActionResult AuditReceipt(ReceiptType type, Guid receiptID)
        {
            switch (type)
            {
                case ReceiptType.InStock:
                    ResolveService<IInStockReceiptService>().AuditReceipt(receiptID, LoginUser.ID);
                    break;
                case ReceiptType.OutStock:
                    ResolveService<IOutStockReceiptService>().AuditReceipt(receiptID, LoginUser.ID);
                    break;
                case ReceiptType.Stocktake:
                    ResolveService<IStocktakeReceiptService>().AuditReceipt(receiptID, LoginUser.ID);
                    break;
                case ReceiptType.StockDamaged:
                    ResolveService<IStockDamagedReceiptService>().AuditReceipt(receiptID, LoginUser.ID);
                    break;
                case ReceiptType.PriceAdjust:
                    ResolveService<IPriceAdjustReceiptService>().AuditReceipt(receiptID, LoginUser.ID);
                    break;
                default:
                    return Json(new JsonResultData
                    {
                        Success = false,
                        ErrorMessage = "参数错误"
                    });
            }

            return Json(new JsonResultData
            {
                Success = true
            });
        } 
        #endregion

        public ActionResult GetSubmittedReceipt(ReceiptType type, Guid id)
        {
            string viewName = null;
            object receipt = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    receipt = ResolveService<IInStockReceiptService>().GetTemporaryReceipt(id);
                    viewName = "InStock";
                    break;
                case ReceiptType.OutStock:
                    receipt = ResolveService<IOutStockReceiptService>().GetTemporaryReceipt(id);
                    viewName = "OutStock";
                    break;
                case ReceiptType.Stocktake:
                    receipt = ResolveService<IStocktakeReceiptService>().GetTemporaryReceipt(id);
                    viewName = "Stocktake";
                    break;
                case ReceiptType.StockDamaged:
                    receipt = ResolveService<IStockDamagedReceiptService>().GetTemporaryReceipt(id);
                    viewName = "StockDamaged";
                    break;
                case ReceiptType.PriceAdjust:
                    receipt = ResolveService<IPriceAdjustReceiptService>().GetTemporaryReceipt(id);
                    viewName = "PriceAdjust";
                    break;
                default:
                    return Content("");
            }

            if (receipt == null)
                return Content("");
            ViewBag.UseLayout = false;
            return View(viewName, receipt);
        }

        public ActionResult GetSubmittedReceiptList(ReceiptType type)
        {
            object receiptList = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    {
                        var list = ResolveService<IInStockReceiptService>().GetTemporaryReceiptList().OrderBy(r => r.NO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.OutStock:
                    {
                        var list = ResolveService<IOutStockReceiptService>().GetTemporaryReceiptList().OrderBy(r => r.NO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.Stocktake:
                    {
                        var list = ResolveService<IStocktakeReceiptService>().GetTemporaryReceiptList().OrderBy(r => r.NO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.StockDamaged:
                    {
                        var list = ResolveService<IStockDamagedReceiptService>().GetTemporaryReceiptList().OrderBy(r => r.NO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.PriceAdjust:
                    {
                        var list = ResolveService<IPriceAdjustReceiptService>().GetTemporaryReceiptList().OrderBy(r => r.NO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
            }

            return Json(receiptList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VoidIndex(ReceiptType type)
        {
            string viewName = null;
            object receiptList = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    {
                        var list = ResolveService<IInStockReceiptService>().GetAuditedReceiptList(null, null);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "InStock";
                        break;
                    }
                case ReceiptType.OutStock:
                    {
                        var list = ResolveService<IOutStockReceiptService>().GetAuditedReceiptList(null, null);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "OutStock";
                        break;
                    }
                case ReceiptType.Stocktake:
                    {
                        var list = ResolveService<IStocktakeReceiptService>().GetAuditedReceiptList(null, null);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "Stocktake";
                        break;
                    }
                case ReceiptType.StockDamaged:
                    {
                        var list = ResolveService<IStockDamagedReceiptService>().GetAuditedReceiptList(null, null);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "StockDamaged";
                        break;
                    }
                case ReceiptType.PriceAdjust:
                    {
                        var list = ResolveService<IPriceAdjustReceiptService>().GetAuditedReceiptList(null, null);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        viewName = "PriceAdjust";
                        break;
                    }
                default:
                    return HttpNotFound("请求的页面不存在");
            }

            ViewBag.UseLayout = true;
            ViewBag.Layout = "~/Views/Shared/VoidReceipt.cshtml";
            ViewBag.ReceiptList = Util.SerializeToJson(receiptList);
            ViewBag.Type = (int)type;
            return View(viewName, null);
        }

        public ActionResult AuditedReceipt(ReceiptType type, Guid id)
        {
            string viewName = null;
            object receipt = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    receipt = ResolveService<IInStockReceiptService>().GetAuditedReceipt(id);
                    viewName = "InStock";
                    break;
                case ReceiptType.OutStock:
                    receipt = ResolveService<IOutStockReceiptService>().GetAuditedReceipt(id);
                    viewName = "OutStock";
                    break;
                case ReceiptType.Stocktake:
                    receipt = ResolveService<IStocktakeReceiptService>().GetAuditedReceipt(id);
                    viewName = "Stocktake";
                    break;
                case ReceiptType.StockDamaged:
                    receipt = ResolveService<IStockDamagedReceiptService>().GetAuditedReceipt(id);
                    viewName = "StockDamaged";
                    break;
                case ReceiptType.PriceAdjust:
                    receipt = ResolveService<IPriceAdjustReceiptService>().GetAuditedReceipt(id);
                    viewName = "PriceAdjust";
                    break;
                default:
                    return Content("");
            }

            if (receipt == null)
                return Content("");
            ViewBag.UseLayout = false;
            return View(viewName, receipt);
        }

        public ActionResult AuditedList(ReceiptType type, string fromNO, string toNO)
        {
            object receiptList = null;

            switch (type)
            {
                case ReceiptType.InStock:
                    {
                        var list = ResolveService<IInStockReceiptService>().GetAuditedReceiptList(fromNO, toNO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.OutStock:
                    {
                        var list = ResolveService<IOutStockReceiptService>().GetAuditedReceiptList(fromNO, toNO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.Stocktake:
                    {
                        var list = ResolveService<IStocktakeReceiptService>().GetAuditedReceiptList(fromNO, toNO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.StockDamaged:
                    {
                        var list = ResolveService<IStockDamagedReceiptService>().GetAuditedReceiptList(fromNO, toNO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                case ReceiptType.PriceAdjust:
                    {
                        var list = ResolveService<IPriceAdjustReceiptService>().GetAuditedReceiptList(fromNO, toNO);
                        receiptList = from r in list
                                      select new { ID = r.ID, NO = r.NO };
                        break;
                    }
                default:
                    return Content("[]");
            }

            return Json(receiptList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult VoidReceipt(ReceiptType type, Guid id)
        {
            try
            {
                switch (type)
                {
                    case ReceiptType.InStock:
                        ResolveService<IInStockReceiptService>().InvalidReceipt(id, LoginUser.ID);
                        break;
                    case ReceiptType.OutStock:
                        ResolveService<IOutStockReceiptService>().InvalidReceipt(id, LoginUser.ID);
                        break;
                    default:
                        return Json(new JsonResultData
                        {
                            Success = false,
                            ErrorMessage = "不支持此单据类型作废"
                        });
                }
            }
            catch (Exception ex)
            {
                return Json(new JsonResultData { 
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }

            return Json(new JsonResultData { 
                Success = true
            });
        }
    }
}
