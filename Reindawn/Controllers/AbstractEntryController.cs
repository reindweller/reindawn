using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Reindawn.Domain.Models;
using Reindawn.Service;
using Reindawn.Service.IdentityHelper;

namespace Reindawn.Controllers
{
    public abstract class AbstractEntryController<TEntity, TViewModel> : Controller
        where TEntity : new()
        where TViewModel : class, new()
    {


        protected abstract TEntity AssignViewModelToEntity(TViewModel viewModel);

        protected abstract TViewModel AssignEntityToViewModel(TEntity entity);
        protected abstract IEntityService<TEntity> GetService();

        protected virtual TViewModel SetViewModelData(TViewModel viewModel)
        {
            return viewModel;
        }
        

        public virtual ActionResult Index(Guid? id = null)
        {
            //var businessId = User.Identity.GetBusinessId();
            var records = GetService().GetAll().Select(AssignEntityToViewModel);
            return View(records);
        }

        public virtual ActionResult Create(Guid? id = null)
        {
            var viewModel = new TViewModel();
            object model = SetViewModelData(viewModel);
            if (model != null)
            {
                return PartialView(model);
            }
            return PartialView();
        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Create(TViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            TEntity entity = AssignViewModelToEntity(viewModel);
            //var helper = new ActionResultHelper<TEntity>(typeof(TViewModel));
            //helper.Method += Add;
            //var businessId = User.Identity.GetBusinessId();
            //if (businessId != null) entity.BusinessId = businessId.Value;
            Add(entity);

            return RedirectToAction("Index");
            //var actionResultMessage = helper.Process(entity, ModelState, _setting.GetMessage(SystemMessageConstant.RecordAdded));

            //return Json(actionResultMessage, JsonRequestBehavior.AllowGet);
        }

        protected void Add(TEntity entity)
        {
            var service = GetService();
            if (service == null) return;

            //var audit = entity as AbstractBaseModel;
            //if (audit != null)
            //{
            //    audit.CreatedBy = SessionManager.GetUserName();
            //    audit.CreatedDate = DateTime.Now;
            //}
            service.Insert(entity);
            service.Save();
        }

        public virtual ActionResult Edit(Guid id)
        {
            //ViewBagId = id;
            //SetViewBagsForEdit(id);
            return LoadEditView(id, false);
        }
        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Edit(TViewModel viewModel)
        {
            TEntity entity = AssignViewModelToEntity(viewModel);
            //var businessId = User.Identity.GetBusinessId();
            //if (businessId != null) entity.BusinessId = businessId.Value;
            //var actionExceptionHelper = new ActionResultHelper<TEntity>(typeof(TViewModel));
            //actionExceptionHelper.Method += Update;
            Update(entity);
            //var result = Validate(entity, _CleanUpControllerName(), "Edit");
            //if (!result.Passed)
            //    _EditReturnPartialViewOnError(viewModel);

            //var actionResultMessage = actionExceptionHelper.Process(entity, ModelState, CrudTransactionResultConstant.Update);
            //var actionResultMessage = actionExceptionHelper.Process(entity, ModelState, _setting.GetMessage(SystemMessageConstant.RecordUpdated));

            //return Json(actionResultMessage, JsonRequestBehavior.AllowGet);
            //return actionResultMessage.ActionStatus == ActionStatusResult.Failed
            //   ? _EditReturnPartialViewOnError(viewModel)
            //   : Json(actionResultMessage, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }
        protected ActionResult LoadEditView(Guid id, bool isPartial)
        {
            var entity = GetRecord(id);
            if (entity == null)
                return isPartial ? (ActionResult)PartialView() : View();

            //_AssignTrailInCreateForEditAction(entity);
            TViewModel viewModel = SetViewModelData(AssignEntityToViewModel(entity));
            return isPartial ? (ActionResult)PartialView(viewModel) : View(viewModel);
        }

        protected TEntity GetRecord(Guid id)
        {
            return GetService().Find(id);
        }

        internal void Update(TEntity entity)
        {
            var service = GetService();
            if (service == null) return;

            //var audit = entity as AbstractBaseModel;
            //if (audit != null)
            //{
            //    _SetCreateAuditFieldValuesForUpdate(audit);
            //    audit.ModifiedBy = SessionContainer.UserName;
            //    audit.ModifiedDate = DateTime.Now;
            //}
            service.Update(entity);
            service.Save();
        }

        public virtual ActionResult Delete(Guid id)
        {
            //var displayData = GetSelectedItems(checkedRecords);
            //return Json(displayData, JsonRequestBehavior.AllowGet);
            //TEntity entity = AssignViewModelToEntity(viewModel);


            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            TEntity entity = GetService().Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(AssignEntityToViewModel(entity));

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            //Student student = _unitOfWork.StudentRepository.GetById((int)id);
            GetService().Delete(id);
            GetService().Save();
            return RedirectToAction("Index");
        }

    }
}