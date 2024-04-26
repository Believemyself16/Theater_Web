<template>
  <v-container>
    <!-- @input là 1 sự kiện của v-tab
    khi ấn đổi tab thì giá trị của tab sẽ được truyển vào hàm qua biến $event -->
    <v-tabs v-model="tab" @input="changeTab($event)" centered class="tab-width">
      <v-tab>ĐĂNG NHẬP</v-tab>
      <v-tab>ĐĂNG KÍ</v-tab>
    </v-tabs>
    <v-row>
      <v-col cols="12">
        <v-card v-if="tab === 0">
          <DangNhap />
        </v-card>
        <v-card v-else-if="tab === 1">
          <DangKi />
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import DangKi from "@/components/Account/DangKi.vue";
import DangNhap from "@/components/Account/DangNhap.vue";
export default {
  name: "ThanhVien",
  components: {
    DangKi,
    DangNhap,
  },
  data() {
    return {
      tab: 0, //index của tab bắt đầu bằng 0
    };
  },
  methods: {
    changeTab(tabIndex) {
      this.tab = tabIndex;
    },
  },
};
</script>

<style scoped>
.tab-width {
  width: 500px !important;
}
</style>
