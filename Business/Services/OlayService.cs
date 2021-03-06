﻿using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Bases;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class OlayService : IOlayService
    {
        private readonly OlayDalBase _olayDal;
        private readonly OlayIhbarDalBase _olayIhbarDal;
        private readonly IhbarDalBase _ihbarDal;

        public OlayService(OlayDalBase olayDal, OlayIhbarDalBase olayIhbarDal, IhbarDalBase ihbarDal)
        {
            _olayDal = olayDal;
            _olayIhbarDal = olayIhbarDal;
            _ihbarDal = ihbarDal;
        }

        public void AddOlay(OlayModel olay, bool seedContext = false)
        {
            try
            {
                Olay olayEntity = new Olay
                {
                    IlkNeden = olay.IlkNeden,
                    OlusSekli = olay.OlusSekli,
                    Yer = olay.Yer,
                    Tarih = new DateTime(olay.Tarih.Value.Year, olay.Tarih.Value.Month, olay.Tarih.Value.Day, Convert.ToInt32(olay.Saat), Convert.ToInt32(olay.Dakika), 0)
                };
                _olayDal.AddEntity(olayEntity);
                olay.Id = olayEntity.Id;
                if (!seedContext)
                {
                    AddOlayIhbarlar(olay);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void UpdateOlayIhbarlar(OlayModel olay)
        {
            DeleteOlayIhbarlar(olay.Id);
            AddOlayIhbarlar(olay);
        }

        private void AddOlayIhbarlar(OlayModel olay)
        {
            List<OlayIhbar> olayIhbarlar;
            OlayIhbar olayIhbarEntity;
            if (olay.IhbarIdleri != null && olay.IhbarIdleri.Count > 0)
            {
                foreach (var ihbarId in olay.IhbarIdleri)
                {
                    olay.Sira = 1;
                    olayIhbarlar = _olayIhbarDal.GetEntities(e => e.IhbarId == ihbarId).OrderBy(e => e.OlaySira).ToList();
                    if (olayIhbarlar != null && olayIhbarlar.Count > 0)
                    {
                        olay.Sira = olayIhbarlar.LastOrDefault().OlaySira + 1;
                    }
                    olayIhbarEntity = new OlayIhbar
                    {
                        OlayId = olay.Id,
                        IhbarId = ihbarId,
                        OlaySira = olay.Sira
                    };
                    _olayIhbarDal.AddEntity(olayIhbarEntity);
                }
            }
        }

        private void DeleteOlayIhbarlar(int olayId)
        {
            List<OlayIhbar> olayIhbarlar = _olayIhbarDal.GetEntities(e => e.OlayId == olayId).ToList();
            if (olayIhbarlar != null && olayIhbarlar.Count > 0)
            {
                _olayIhbarDal.Commit = false;
                foreach (var olayIhbar in olayIhbarlar)
                {
                    _olayIhbarDal.DeleteEntity(olayIhbar);
                }
                _olayIhbarDal.SaveChanges();
            }
        }

        public void UpdateOlay(OlayModel olay)
        {
            try
            {
                Olay olayEntity = new Olay
                {
                    Id = olay.Id,
                    Guid = olay.Guid,
                    IlkNeden = olay.IlkNeden,
                    OlusSekli = olay.OlusSekli,
                    Yer = olay.Yer,
                    Tarih = new DateTime(olay.Tarih.Value.Year, olay.Tarih.Value.Month, olay.Tarih.Value.Day, Convert.ToInt32(olay.Saat), Convert.ToInt32(olay.Dakika), 0)
                };
                _olayDal.UpdateEntity(olayEntity);
                UpdateOlayIhbarlar(olay);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void DeleteOlay(int id)
        {
            try
            {
                DeleteOlayIhbarlar(id);
                _olayDal.DeleteEntity(id);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private IQueryable<OlayModel> GetOlayQuery(int? id = null)
        {
            var olayQuery = _olayDal.GetEntityQuery();
            var olayIhbarQuery = _olayIhbarDal.GetEntityQuery();
            var ihbarQuery = _ihbarDal.GetEntityQuery();
            var query = from olay in olayQuery
                        join olayIhbar in olayIhbarQuery
                            on olay.Id equals olayIhbar.OlayId into olayOlayIhbarJoin
                        from olayOlayIhbar in olayOlayIhbarJoin.DefaultIfEmpty()
                        join ihbar in ihbarQuery
                            on olayOlayIhbar.IhbarId equals ihbar.Id into olayIhbarIhbarJoin
                        from olayIhbarIhbar in olayIhbarIhbarJoin.DefaultIfEmpty()
                        select new OlayModel
                        {
                            Id = olay.Id,
                            Guid = olay.Guid,
                            IlkNeden = olay.IlkNeden,
                            OlusSekli = olay.OlusSekli,
                            Yer = olay.Yer,
                            Tarih = olay.Tarih,
                            TarihText = olay.Tarih.ToShortDateString() + " " + olay.Tarih.ToLongTimeString(),
                            Sira = olayOlayIhbar == null ? 1 : olayOlayIhbar.OlaySira,
                            IhbarId = olayIhbarIhbar.Id,
                            IhbarOzeti = olayIhbarIhbar.Ozet
                        };
            query = query.OrderBy(e => e.IhbarId).ThenBy(e => e.Sira);
            if (id != null)
                query = query.Where(e => e.Id == id.Value);
            return query;
        }

        public List<OlayModel> GetOlaylar()
        {
            try
            {
                IQueryable<OlayModel> query = GetOlayQuery();
                List<OlayModel> olaylarModel = query.ToList();
                return olaylarModel;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public OlayModel GetOlay(int id)
        {
            try
            {
                IQueryable<OlayModel> query = GetOlayQuery(id);
                List<OlayModel> olaylar = query.ToList();
                OlayModel olay = new OlayModel
                {
                    Id = olaylar.FirstOrDefault().Id,
                    Guid = olaylar.FirstOrDefault().Guid,
                    IlkNeden = olaylar.FirstOrDefault().IlkNeden,
                    OlusSekli = olaylar.FirstOrDefault().OlusSekli,
                    Yer = olaylar.FirstOrDefault().Yer,
                    Tarih = olaylar.FirstOrDefault().Tarih,
                    TarihText = olaylar.FirstOrDefault().Tarih.Value.ToShortDateString(),
                    Zaman = olaylar.FirstOrDefault().Tarih.Value.ToLongTimeString(),
                    IhbarIdleri = olaylar.Select(e => e.IhbarId ?? 0).ToList(),
                    IhbarOzetleri = olaylar.Select(e => e.IhbarOzeti).ToList()
                };
                return olay;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
