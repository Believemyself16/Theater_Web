<template>
  <v-container fluid>
    <v-carousel cycle interval="4000" hide-delimiter-background>
      <v-carousel-item v-for="(item, index) in carouselItem" :key="index">
        <v-img :src="item.img"></v-img>
      </v-carousel-item>
    </v-carousel>
  </v-container>
</template>

<script>
export default {
  name: "SlideShow",
  data() {
    return {
      carouselItem: [
        {
          img: require("@/assets/SlideShow/huong-dan-dang-nhap.png"),
          link: "https://betacinemas.vn/tin-ben-le/huong-dan-dang-nhap-tai-khoan-beta-cinemas.htm",
        },
        {
          img: require("@/assets/SlideShow/sap-khai-truong.png"),
          link: "https://betacinemas.vn/beta-cinemas-ung-van-khiem-sieu-pham-trong-thoi-gian-toi.htm",
        },
        {
          img: require("@/assets/SlideShow/combo-hoc-sinh-sinh-vien.png"),
          link: "https://betacinemas.vn/khuyen-mai-moi/99k-tau-ngay-ve-va-combo-bap-nuoc.htm",
        },
        {
          img: require("@/assets/SlideShow/deal-nong-bong-don-he-sang.png"),
          link: "https://betacinemas.vn/khuyen-mai-moi/deal-nong-bong-hong-he-sang.htm",
        },
        {
          img: require("@/assets/SlideShow/he-ruc-chay-sale-cham-day.png"),
          link: "https://betacinemas.vn/khuyen-mai-moi/he-ruc-chay-sale-cham-day.htm",
        },
      ],
    };
  },
};
</script>
